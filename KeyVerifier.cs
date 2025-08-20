// KeyVerifier.cs
// Necesitarás añadir el paquete NuGet: System.Net.Http y Newtonsoft.Json

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public static class KeyVerifier
{
    private static readonly string ApiUrl = "http://mx-1.ba.supercores.host:30014/verify";
    private static readonly HttpClient client = new HttpClient();

    public class ApiResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public static async Task<ApiResponse> VerifyKeyAsync(string key)
    {
        try
        {
            string hwid = GetMachineGuid();
            var payload = new { key = key, hwid = hwid };
            string jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(ApiUrl, content);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            // --- INICIO DE LA SECCIÓN DE DEPURACIÓN MEJORADA ---

            // Si la respuesta del servidor no fue exitosa (ej. error 404, 500, etc.)
            if (!response.IsSuccessStatusCode)
            {
                return new ApiResponse
                {
                    Status = "error",
                    Message = $"El servidor respondió con un error. Código: {(int)response.StatusCode} ({response.ReasonPhrase}). Respuesta: {jsonResponse}"
                };
            }

            // --- FIN DE LA SECCIÓN DE DEPURACIÓN MEJORADA ---

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

            if (apiResponse == null)
            {
                return new ApiResponse { Status = "error", Message = "No se pudo interpretar la respuesta del servidor." };
            }

            return apiResponse;
        }
        catch (Exception ex)
        {
            return new ApiResponse { Status = "error", Message = $"Error de conexión: {ex.Message}" };
        }
    }

    private static string GetMachineGuid()
    {
        string location = @"SOFTWARE\Microsoft\Cryptography";
        string name = "MachineGuid";

        using (var localMachineX64View = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64))
        {
            using (var rk = localMachineX64View.OpenSubKey(location))
            {
                if (rk == null) throw new KeyNotFoundException($"No se encontró la clave del registro: {location}");
                object machineGuid = rk.GetValue(name);
                if (machineGuid == null) throw new IndexOutOfRangeException($"No se encontró el valor del registro: {name}");
                return machineGuid.ToString();
            }
        }
    }
}
