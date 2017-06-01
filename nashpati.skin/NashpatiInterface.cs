using System;
using System.Threading.Tasks;
using Refit;

namespace nashpati.skin
{
	public interface NashpatiInterface
	{
		[Headers("Content-Type: application/json")]
		[Post("/api/video/")]
		Task<VideoResponse> SubmitVideo([Body] string body);

		[Headers("Content-Type: application/json")]
		[Get("/api/video/{id}")]
		Task<VideoResponse> GetVideoInfo(int id);

		[Headers("Content-Type: application/json")]
		[Post("/api/video/{video_id}/formats/{format_id}")]
		Task<FormatResponse> StartDownload([AliasAs("video_id")] int videoId, [AliasAs("format_id")] string formatId, [Body] string body = null);

		[Headers("Content-Type: application/json")]
		[Get("/api/video/{video_id}/formats/{format_id}")]
		Task<FormatResponse> GetDownlaod([AliasAs("video_id")] int videoId, [AliasAs("format_id")] string formatId);
	}
}
