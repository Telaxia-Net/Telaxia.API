﻿namespace texlaxia_backend.Telaxia.Resources;

public class UserResource
{
    public int Id { get; set; }
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public string Phone{ get; set; }
    public string Mail{ get; set; }
    public int PlanId{ get; set; }
    public int Rating { get; set; }
}