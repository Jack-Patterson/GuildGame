namespace com.Halcyon.API.Core.Camera;

public interface ICameraParameters
{
    RigParameters TopRigMinimum { get; }
    RigParameters MiddleRigMinimum { get; }
    RigParameters BottomRigMinimum { get; }

    RigParameters TopRigMaximum { get; }
    RigParameters MiddleRigMaximum { get; }
    RigParameters BottomRigMaximum { get; }
    
    RigParameters TopRigCurrent { get; set; }
    RigParameters MiddleRigCurrent { get; set; }
    RigParameters BottomRigCurrent { get; set; }
}