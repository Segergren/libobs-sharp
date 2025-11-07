using System;
using System.Runtime.InteropServices;

namespace LibObs
{
    using obs_data_t = IntPtr;
    using obs_service_t = IntPtr;

    public partial class Obs
    {
        /// <summary>
        /// Creates a service with the specified settings.
        /// https://docs.obsproject.com/reference-services
        /// </summary>
        /// <param name="id">The service type string identifier</param>
        /// <param name="name">The desired name of the service</param>
        /// <param name="settings">The settings for the service, or NULL if none</param>
        /// <param name="hotkey_data">Saved hotkey data for the service, or NULL if none</param>
        /// <returns>A reference to the newly created service, or NULL if failed</returns>
        [DllImport(importLibrary, CallingConvention = importCall, CharSet = importCharSet)]
        public static extern obs_service_t obs_service_create(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string id,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string name,
            obs_data_t settings,
            obs_data_t hotkey_data);

        /// <summary>
        /// Releases a reference to a service. When the last reference is released, the service is destroyed.
        /// https://docs.obsproject.com/reference-services
        /// </summary>
        /// <param name="service">The service to release</param>
        [DllImport(importLibrary, CallingConvention = importCall)]
        public static extern void obs_service_release(obs_service_t service);

        /// <summary>
        /// Sets the service for outputs that require services (such as RTMP outputs).
        /// https://docs.obsproject.com/reference-outputs
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="service">The service</param>
        [DllImport(importLibrary, CallingConvention = importCall)]
        public static extern void obs_output_set_service(IntPtr output, obs_service_t service);

        /// <summary>
        /// Gets the service for an output.
        /// https://docs.obsproject.com/reference-outputs
        /// </summary>
        /// <param name="output">The output</param>
        /// <returns>The service (reference is not incremented)</returns>
        [DllImport(importLibrary, CallingConvention = importCall)]
        public static extern obs_service_t obs_output_get_service(IntPtr output);
    }
}
