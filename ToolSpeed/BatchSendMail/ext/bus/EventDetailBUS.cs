﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

/// <summary>
/// Summary description for EventDetailBUS
/// </summary>
public class EventDetailBUS:IEventDetail
{
    public EventDetailBUS() { }

    EventDetailDAO edDao = new EventDetailDAO();
    #region IEventDetail Members

    public void tblEventDetail_insert(EventDetailDTO dt)
    {
        edDao.tblEventDetail_insert(dt);
    }

    public void tblEventDetail_Update(EventDetailDTO dt)
    {
        edDao.tblEventDetail_Update(dt);
    }

    public void tblEventDetail_Delete(int EventId)
    {
        edDao.tblEventDetail_Delete(EventId);
    }

    public DataTable GetAll()
    {
        return edDao.GetAll();
    }

    public DataTable GetByID(int EventId)
    {
        return edDao.GetByID(EventId);
    }

    public DataTable GetByGroupId(int GroupId)
    {
        return edDao.GetByGroupId(GroupId);
    }

    public DataTable GetByIdAndEmail(int EventId, string email)
    {
        return edDao.GetByIdAndEmail(EventId, email);
    }

    #endregion
}
