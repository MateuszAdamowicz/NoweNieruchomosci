﻿using Models.ViewModels;

namespace Services.CRUDAdvertServices.ReadAdvertService
{
    public interface IReadAdvertService
    {
        ShowAdvertViewModel GetAdvertById(int id);
        CreateAdvertViewModel GetCreateAdvertById(int id);
        ShowAdvertViewModel GetAdvertByIdIncludeHidden(int id);
    }
}