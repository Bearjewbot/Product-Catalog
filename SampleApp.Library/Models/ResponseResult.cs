using System;

namespace SampleApp.Library.Models;

public class ResponseResult
{
	public string _message { get; set; } = null!;

	public object _data { get; set; } = null!;

	public bool _result { get; set; }
}
