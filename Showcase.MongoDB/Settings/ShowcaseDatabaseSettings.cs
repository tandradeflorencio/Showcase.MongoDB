﻿namespace Showcase.MongoDB.Settings
{
    public class ShowcaseDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CustomersCollectionName { get; set; } = null!;
    }
}
