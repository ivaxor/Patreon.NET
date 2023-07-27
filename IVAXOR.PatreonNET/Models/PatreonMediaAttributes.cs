using System.Text.Json.Serialization;
using System;
using IVAXOR.PatreonNET.Models.Response.Interfaces;

namespace IVAXOR.PatreonNET.Models
{
    /// <summary>
    /// A file uploaded to patreon.com, usually an image.
    /// </summary>
    public class PatreonMediaAttributes : IPatreonAttributes
    {
        /// <summary>
        /// When the file was created.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The URL to download this media.
        /// Valid for 24 hours.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("download_url")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// File name.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("file_name")]
        public string FileName { get; set; }

        /// <summary>
        /// The resized image URLs for this media.
        /// Valid for 2 weeks.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("image_urls")]
        public string ImageUrls { get; set; }

        /// <summary>
        /// Metadata related to the file.
        /// </summary>
        [JsonPropertyName("metadata")]
        public string? Metadata { get; set; }

        /// <summary>
        /// Mimetype of uploaded file, eg: "application/jpeg".
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("mimetype")]
        public string Mimetype { get; set; }

        /// <summary>
        /// Ownership id.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        /// <summary>
        /// Ownership relationship type for multi-relationship medias.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("owner_relationship")]
        public string OwnerRelationship { get; set; }

        /// <summary>
        /// Type of the resource that owns the file.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("owner_type")]
        public string OwnerType { get; set; }

        /// <summary>
        /// Size of file in bytes.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("size_bytes")]
        public int SizeBytes { get; set; }

        /// <summary>
        /// The state of the file.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("state")]
        public int State { get; set; }

        /// <summary>
        /// When the upload URL expires.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("upload_expires_at")]
        public DateTime UploadExpiresAt { get; set; }

        /// <summary>
        /// All the parameters that have to be added to the upload form request.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("upload_parameters")]
        public string UploadParameters { get; set; }

        /// <summary>
        /// The URL to perform a POST request to in order to upload the media file.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("upload_url")]
        public string UploadUrl { get; set; }
    }
}
