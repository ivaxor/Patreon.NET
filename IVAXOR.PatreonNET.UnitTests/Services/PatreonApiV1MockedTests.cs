using IVAXOR.PatreonNET.Services.API;

namespace IVAXOR.PatreonNET.UnitTests.Services;

[TestClass]
public class PatreonAPIv1MockedTests
{
    protected readonly Mock<HttpMessageHandler> HttpMessageHandlerMock;

    protected readonly PatreonAPIv1 PatreonAPIv1;

    public PatreonAPIv1MockedTests()
    {
        HttpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        var httpClient = new HttpClient(HttpMessageHandlerMock.Object);

        var patreonTokenManagerMock = new Mock<IPatreonTokenManager>();
        patreonTokenManagerMock
            .Setup(_ => _.AccessToken)
            .Returns("TestAccessToken");

        PatreonAPIv1 = new(httpClient, patreonTokenManagerMock.Object);
    }

    [TestMethod]
    public async Task CurrentUser()
    {
        // Arrange
        HttpMessageHandlerMock
          .Protected()
          .Setup<Task<HttpResponseMessage>>(
             "SendAsync",
             ItExpr.IsAny<HttpRequestMessage>(),
             ItExpr.IsAny<CancellationToken>()
          )
          .ReturnsAsync(new HttpResponseMessage()
          {
              StatusCode = HttpStatusCode.OK,
              Content = new StringContent("{\"data\":{\"attributes\":{\"about\":null,\"age_verification_status\":null,\"apple_id\":null,\"can_see_nsfw\":null,\"created\":\"2023-07-27T01:09:24.000+00:00\",\"default_country_code\":null,\"discord_id\":null,\"email\":\"patreon.net@ivaxor.com\",\"facebook\":null,\"facebook_id\":null,\"first_name\":\"Patreon.NET\",\"full_name\":\"Patreon.NET\",\"gender\":0,\"google_id\":null,\"has_password\":false,\"image_url\":\"https://c8.patreon.com/2/200/97752217\",\"is_deleted\":false,\"is_eligible_for_idv\":false,\"is_email_verified\":true,\"is_nuked\":false,\"is_suspended\":false,\"last_name\":\"\",\"patron_currency\":null,\"social_connections\":{\"deviantart\":null,\"discord\":null,\"facebook\":null,\"google\":null,\"instagram\":null,\"reddit\":null,\"spotify\":null,\"spotify_open_access\":null,\"twitch\":null,\"twitter\":null,\"vimeo\":null,\"youtube\":null},\"thumb_url\":\"https://c8.patreon.com/2/200/97752217\",\"twitch\":null,\"twitter\":null,\"url\":\"https://www.patreon.com/user?u=97752217\",\"vanity\":null,\"youtube\":null},\"id\":\"97752217\",\"relationships\":{\"campaign\":{\"data\":{\"id\":\"10855995\",\"type\":\"campaign\"},\"links\":{\"related\":\"https://www.patreon.com/api/campaigns/10855995\"}},\"pledges\":{\"data\":[]}},\"type\":\"user\"},\"included\":[{\"attributes\":{\"avatar_photo_image_urls\":{\"default\":\"https://c8.patreon.com/2/620/c10855995\",\"default_small\":\"https://c8.patreon.com/2/360/c10855995\",\"original\":\"https://c8.patreon.com/2/None/c10855995\",\"thumbnail\":\"https://c8.patreon.com/2/360/c10855995\",\"thumbnail_large\":\"https://c8.patreon.com/2/1080/c10855995\",\"thumbnail_small\":\"https://c8.patreon.com/2/100/c10855995\"},\"avatar_photo_url\":\"https://c8.patreon.com/2/200/c10855995\",\"campaign_pledge_sum\":0,\"cover_photo_url\":null,\"cover_photo_url_sizes\":{},\"created_at\":\"2023-07-27T01:10:39.000+00:00\",\"creation_count\":0,\"creation_name\":null,\"currency\":\"USD\",\"discord_server_id\":null,\"display_patron_goals\":false,\"earnings_visibility\":\"public\",\"image_small_url\":\"None\",\"image_url\":null,\"is_charge_upfront\":true,\"is_charged_immediately\":true,\"is_monthly\":true,\"is_nsfw\":false,\"is_plural\":false,\"main_video_embed\":null,\"main_video_url\":null,\"name\":\"Patreon.NET\",\"one_liner\":null,\"outstanding_payment_amount_cents\":0,\"paid_member_count\":0,\"patron_count\":0,\"pay_per_name\":\"month\",\"pledge_sum\":0,\"pledge_sum_currency\":\"USD\",\"pledge_url\":\"/join/10855995\",\"published_at\":null,\"summary\":null,\"thanks_embed\":null,\"thanks_msg\":null,\"thanks_video_url\":null,\"url\":\"https://www.patreon.com/user?u=97752217\"},\"id\":\"10855995\",\"relationships\":{\"creator\":{\"data\":{\"id\":\"97752217\",\"type\":\"user\"},\"links\":{\"related\":\"https://www.patreon.com/api/user/97752217\"}},\"goals\":{\"data\":null},\"rewards\":{\"data\":[{\"id\":\"-1\",\"type\":\"reward\"},{\"id\":\"0\",\"type\":\"reward\"}]}},\"type\":\"campaign\"},{\"attributes\":{\"amount\":0,\"amount_cents\":0,\"created_at\":null,\"description\":\"Everyone\",\"patron_currency\":\"USD\",\"remaining\":0,\"requires_shipping\":false,\"url\":null,\"user_limit\":null},\"id\":\"-1\",\"type\":\"reward\"},{\"attributes\":{\"amount\":1,\"amount_cents\":1,\"created_at\":null,\"description\":\"Patrons Only\",\"patron_currency\":\"USD\",\"remaining\":0,\"requires_shipping\":false,\"url\":null,\"user_limit\":null},\"id\":\"0\",\"type\":\"reward\"}],\"links\":{\"self\":\"https://www.patreon.com/api/user/97752217\"}}"),
          });

        // Act
        var currentUser = await PatreonAPIv1.CurrentUser().ExecuteAsync();

        // Assert
        Assert.AreEqual("97752217", currentUser.Data.Id);
        Assert.AreEqual("user", currentUser.Data.Type);

        Assert.AreEqual("patreon.net@ivaxor.com", currentUser.Data.Attributes.Email);
        Assert.AreEqual("Patreon.NET", currentUser.Data.Attributes.FirstName);
        Assert.AreEqual("Patreon.NET", currentUser.Data.Attributes.FullName);
        Assert.AreEqual(0, currentUser.Data.Attributes.Gender);
        Assert.AreEqual(false, currentUser.Data.Attributes.HasPassword);
        Assert.AreEqual("https://c8.patreon.com/2/200/97752217", currentUser.Data.Attributes.ImageUrl);
        Assert.AreEqual(false, currentUser.Data.Attributes.IsDeleted);
        Assert.AreEqual(false, currentUser.Data.Attributes.IsEligibleForIdv);
        Assert.AreEqual(true, currentUser.Data.Attributes.IsEmailVerified);
        Assert.AreEqual(false, currentUser.Data.Attributes.IsNuked);
        Assert.AreEqual(false, currentUser.Data.Attributes.IsSuspended);
        Assert.AreEqual("", currentUser.Data.Attributes.LastName);
        Assert.AreEqual("https://c8.patreon.com/2/200/97752217", currentUser.Data.Attributes.ThumbUrl);
        Assert.AreEqual("https://www.patreon.com/user?u=97752217", currentUser.Data.Attributes.Url);

        Assert.AreEqual("10855995", currentUser.Data.Relationships.Campaign.Data.Id);
        Assert.AreEqual("campaign", currentUser.Data.Relationships.Campaign.Data.Type);
        Assert.AreEqual("https://www.patreon.com/api/campaigns/10855995", currentUser.Data.Relationships.Campaign.Links.Related);

        Assert.AreEqual(1, currentUser.Included.Count(_ => _.Type == "campaign"));
        Assert.AreEqual(2, currentUser.Included.Count(_ => _.Type == "reward"));

        Assert.AreEqual("https://www.patreon.com/api/user/97752217", currentUser.Links.Self);
    }

    [TestMethod]
    public async Task CurrentUserCampaigns()
    {
        // Arrange
        HttpMessageHandlerMock
          .Protected()
          .Setup<Task<HttpResponseMessage>>(
             "SendAsync",
             ItExpr.IsAny<HttpRequestMessage>(),
             ItExpr.IsAny<CancellationToken>()
          )
          .ReturnsAsync(new HttpResponseMessage()
          {
              StatusCode = HttpStatusCode.OK,
              Content = new StringContent("{\"data\":[{\"attributes\":{\"avatar_photo_image_urls\":{\"default\":\"https://c8.patreon.com/2/620/c10855995\",\"default_small\":\"https://c8.patreon.com/2/360/c10855995\",\"original\":\"https://c8.patreon.com/2/None/c10855995\",\"thumbnail\":\"https://c8.patreon.com/2/360/c10855995\",\"thumbnail_large\":\"https://c8.patreon.com/2/1080/c10855995\",\"thumbnail_small\":\"https://c8.patreon.com/2/100/c10855995\"},\"avatar_photo_url\":\"https://c8.patreon.com/2/200/c10855995\",\"campaign_pledge_sum\":0,\"cover_photo_url\":null,\"cover_photo_url_sizes\":{},\"created_at\":\"2023-07-27T01:10:39.000+00:00\",\"creation_count\":0,\"creation_name\":null,\"currency\":\"USD\",\"discord_server_id\":null,\"display_patron_goals\":false,\"earnings_visibility\":\"public\",\"image_small_url\":\"None\",\"image_url\":null,\"is_charge_upfront\":true,\"is_charged_immediately\":true,\"is_monthly\":true,\"is_nsfw\":false,\"is_plural\":false,\"main_video_embed\":null,\"main_video_url\":null,\"name\":\"Patreon.NET\",\"one_liner\":null,\"outstanding_payment_amount_cents\":0,\"paid_member_count\":0,\"patron_count\":0,\"pay_per_name\":\"month\",\"pledge_sum\":0,\"pledge_sum_currency\":\"USD\",\"pledge_url\":\"/join/10855995\",\"published_at\":null,\"summary\":null,\"thanks_embed\":null,\"thanks_msg\":null,\"thanks_video_url\":null,\"url\":\"https://www.patreon.com/user?u=97752217\"},\"id\":\"10855995\",\"relationships\":{\"creator\":{\"data\":{\"id\":\"97752217\",\"type\":\"user\"},\"links\":{\"related\":\"https://www.patreon.com/api/user/97752217\"}},\"goals\":{\"data\":null},\"rewards\":{\"data\":[{\"id\":\"-1\",\"type\":\"reward\"},{\"id\":\"0\",\"type\":\"reward\"}]}},\"type\":\"campaign\"}],\"included\":[{\"attributes\":{\"about\":null,\"age_verification_status\":null,\"apple_id\":null,\"can_see_nsfw\":null,\"created\":\"2023-07-27T01:09:24.000+00:00\",\"default_country_code\":null,\"discord_id\":null,\"email\":\"patreon.net@ivaxor.com\",\"facebook\":null,\"facebook_id\":null,\"first_name\":\"Patreon.NET\",\"full_name\":\"Patreon.NET\",\"gender\":0,\"google_id\":null,\"has_password\":false,\"image_url\":\"https://c8.patreon.com/2/200/97752217\",\"is_deleted\":false,\"is_eligible_for_idv\":false,\"is_email_verified\":true,\"is_nuked\":false,\"is_suspended\":false,\"last_name\":\"\",\"patron_currency\":null,\"social_connections\":{\"deviantart\":null,\"discord\":null,\"facebook\":null,\"google\":null,\"instagram\":null,\"reddit\":null,\"spotify\":null,\"spotify_open_access\":null,\"twitch\":null,\"twitter\":null,\"vimeo\":null,\"youtube\":null},\"thumb_url\":\"https://c8.patreon.com/2/200/97752217\",\"twitch\":null,\"twitter\":null,\"url\":\"https://www.patreon.com/user?u=97752217\",\"vanity\":null,\"youtube\":null},\"id\":\"97752217\",\"relationships\":{\"campaign\":{\"data\":{\"id\":\"10855995\",\"type\":\"campaign\"},\"links\":{\"related\":\"https://www.patreon.com/api/campaigns/10855995\"}}},\"type\":\"user\"},{\"attributes\":{\"amount\":0,\"amount_cents\":0,\"created_at\":null,\"description\":\"Everyone\",\"patron_currency\":\"USD\",\"remaining\":0,\"requires_shipping\":false,\"url\":null,\"user_limit\":null},\"id\":\"-1\",\"type\":\"reward\"},{\"attributes\":{\"amount\":1,\"amount_cents\":1,\"created_at\":null,\"description\":\"Patrons Only\",\"patron_currency\":\"USD\",\"remaining\":0,\"requires_shipping\":false,\"url\":null,\"user_limit\":null},\"id\":\"0\",\"type\":\"reward\"}]}")
          });

        // Act
        var currentUserCampaings = await PatreonAPIv1.CurrentUserCampaigns().ExecuteAsync();

        // Assert
        Assert.AreEqual("10855995", currentUserCampaings.Data.Single().Id);
        Assert.AreEqual("campaign", currentUserCampaings.Data.Single().Type);

        Assert.AreEqual("https://c8.patreon.com/2/620/c10855995", currentUserCampaings.Data.Single().Attributes.AvatarPhotoImageUrls.Default);
        Assert.AreEqual("https://c8.patreon.com/2/360/c10855995", currentUserCampaings.Data.Single().Attributes.AvatarPhotoImageUrls.DefaultSsmall);
        Assert.AreEqual("https://c8.patreon.com/2/None/c10855995", currentUserCampaings.Data.Single().Attributes.AvatarPhotoImageUrls.Original);
        Assert.AreEqual("https://c8.patreon.com/2/360/c10855995", currentUserCampaings.Data.Single().Attributes.AvatarPhotoImageUrls.Thumbnail);
        Assert.AreEqual("https://c8.patreon.com/2/1080/c10855995", currentUserCampaings.Data.Single().Attributes.AvatarPhotoImageUrls.ThumbnailLarge);
        Assert.AreEqual("https://c8.patreon.com/2/100/c10855995", currentUserCampaings.Data.Single().Attributes.AvatarPhotoImageUrls.ThumbnailSmall);

        Assert.AreEqual("https://c8.patreon.com/2/200/c10855995", currentUserCampaings.Data.Single().Attributes.AvatarPhotoUrl);
        Assert.AreEqual(0, currentUserCampaings.Data.Single().Attributes.CampaignPledgeSum);
        Assert.AreEqual(0, currentUserCampaings.Data.Single().Attributes.CreationCount);
        Assert.AreEqual("USD", currentUserCampaings.Data.Single().Attributes.Currency);
        Assert.AreEqual(false, currentUserCampaings.Data.Single().Attributes.DisplayPatronGoals);
        Assert.AreEqual("public", currentUserCampaings.Data.Single().Attributes.EarningsVisibility);
        Assert.AreEqual("None", currentUserCampaings.Data.Single().Attributes.ImageSmallUrl);
        Assert.AreEqual(true, currentUserCampaings.Data.Single().Attributes.IsChargeUpfront);
        Assert.AreEqual(true, currentUserCampaings.Data.Single().Attributes.IsChargedImmediately);
        Assert.AreEqual(true, currentUserCampaings.Data.Single().Attributes.IsMonthly);
        Assert.AreEqual(false, currentUserCampaings.Data.Single().Attributes.IsNsfw);
        Assert.AreEqual(false, currentUserCampaings.Data.Single().Attributes.IsPlural);
        Assert.AreEqual("Patreon.NET", currentUserCampaings.Data.Single().Attributes.Name);
        Assert.AreEqual(0, currentUserCampaings.Data.Single().Attributes.OutstandingPaymentAmountCents);
        Assert.AreEqual(0, currentUserCampaings.Data.Single().Attributes.PaidMemberCcount);
        Assert.AreEqual(0, currentUserCampaings.Data.Single().Attributes.PatronCount);
        Assert.AreEqual("month", currentUserCampaings.Data.Single().Attributes.PayPerName);
        Assert.AreEqual(0, currentUserCampaings.Data.Single().Attributes.PledgeSum);
        Assert.AreEqual("USD", currentUserCampaings.Data.Single().Attributes.PledgeSumCurrency);
        Assert.AreEqual("/join/10855995", currentUserCampaings.Data.Single().Attributes.PledgeUrl);
        Assert.AreEqual("https://www.patreon.com/user?u=97752217", currentUserCampaings.Data.Single().Attributes.Url);

        Assert.AreEqual("97752217", currentUserCampaings.Data.Single().Relationships.Creator.Data.Id);
        Assert.AreEqual("https://www.patreon.com/api/user/97752217", currentUserCampaings.Data.Single().Relationships.Creator.Links.Related);

        Assert.AreEqual("-1", currentUserCampaings.Data.Single().Relationships.Rewards.Data.First().Id);
        Assert.AreEqual("0", currentUserCampaings.Data.Single().Relationships.Rewards.Data.Last().Id);

        Assert.AreEqual(1, currentUserCampaings.Included.Count(_ => _.Type == "user"));
        Assert.AreEqual(2, currentUserCampaings.Included.Count(_ => _.Type == "reward"));
    }
}
