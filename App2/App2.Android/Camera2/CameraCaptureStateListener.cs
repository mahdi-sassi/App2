﻿using Android.Hardware.Camera2;
using System;

namespace App2.Droid.Camera2
{
	public class CameraCaptureStateListener : CameraCaptureSession.StateCallback
	{
		public Action<CameraCaptureSession> OnConfigureFailedAction;

		public Action<CameraCaptureSession> OnConfiguredAction;

		public override void OnConfigureFailed(CameraCaptureSession session)
		{
			OnConfigureFailedAction?.Invoke(session);
		}

		public override void OnConfigured(CameraCaptureSession session)
		{
			OnConfiguredAction?.Invoke(session);
		}
	}
}
