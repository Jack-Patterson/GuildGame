﻿using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.API.Core.Camera;

namespace com.Halcyon.API.Services.DataHolder;

public interface IDataHolderService
{
    List<IBuilderItem> BuilderItems { get; }
    ICameraParameters CameraParameters { get; set; }

    bool SaveData(string relativeSaveLocation);
    IDataHolderService LoadData(string relativeSaveLocation);
}