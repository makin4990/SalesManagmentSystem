﻿using Nest;

namespace CoreFramework.ElasticSearch.Models;

public class ElasticSearchModel
{
    public Id ElasticId { get; set; }
    public string IndexName { get; set; }
}