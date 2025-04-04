﻿using System;
using System.Runtime.InteropServices;

namespace LibObs {
    using obs_scene_t = IntPtr;
    using obs_sceneitem_t = IntPtr;
    using obs_source_t = IntPtr;

    public partial class Obs {
        [DllImport(importLibrary, CallingConvention = importCall, CharSet = importCharSet)]
        public static extern obs_scene_t obs_scene_create(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string name);

        [DllImport(importLibrary, CallingConvention = importCall)]
        public static extern obs_sceneitem_t obs_scene_add(obs_scene_t scene, obs_source_t source);

        [DllImport(importLibrary, CallingConvention = importCall)]
        public static extern obs_source_t obs_scene_get_source(obs_scene_t scene);

        [DllImport(importLibrary, CallingConvention = importCall)]
        public static extern void obs_scene_release(obs_scene_t scene);
    }
}