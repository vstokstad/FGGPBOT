// FGGPBOTPublicModule.cs2020Vilhelm Stokstad

using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace BOTone {
    public class PublicModule : ModuleBase<SocketCommandContext> {
        // Dependency Injection will fill this value in for us
        public PictureService? PictureService { get; set; }

        [Command("commands")]
        public Task Commands() => ReplyAsync("!commands : this list of commands\n" +
                                             "!ping : ping the bot\n" +
                                             "!cat : MJAU\n" +
                                             "!friday : thank god its friday.\n" +
                                             "!userinfo : who are you?\n" +
                                             "!canvas-cal : link to subscribable canvas cal.\n" +
                                             "!teams : what is teh teams link for current class!?!?!?\n" +
                                             "!canvas : canvas login\n" +
                                             "!canvas-list : Google Doc with all current Courses pulled from Canvas API");
    
        [Command("ping")]
        [Alias("pong", "hello")]
        public Task PingAsync()
            => ReplyAsync("pong!");

        [Command("cat")]
        public async Task CatAsync(){
            // Get a stream containing an image of a cat
            var stream = await PictureService.GetCatPictureAsync();
            // Streams must be seeked to their beginning before being uploaded!
            stream.Seek(0, SeekOrigin.Begin);
            await Context.Channel.SendFileAsync(stream, "cat.png");
        }

        [Command("friday")]
        public async Task FridayAsync(){
            await ReplyAsync("https://www.youtube.com/watch?v=xZ8DCHA7G3Q&ab_channel=AxxAL@");
        }

        // Get info on a user, or the user who invoked the command if one is not specified
        [Command("userinfo")]
        public async Task UserInfoAsync(IUser user = null){
            user ??= Context.User;
            await ReplyAsync(user.ToString());
        }

        [Command("canvas-cal")]
        public Task CalendarAsync() =>
            ReplyAsync(
                "https://changemakereducations.instructure.com/feeds/calendars/user_fWCUnBCCeE0EDDrOo9fUTBv9hoZx0gdNxgHNWpTL");

        [Command("teams")]
        public Task TeamsAsync() => ReplyAsync("@Krister Do you have the Teams link for the current lecture?");

        [Command("canvas")]
        public Task CanvasAsync() => ReplyAsync("https://changemakereducations.instructure.com/login/canvas");

        [Command("canvas-list")]
        public Task CanvasListAsync() =>
            ReplyAsync(
                "https://docs.google.com/spreadsheets/d/1Pubg1dHWfmMWzuYubT41zhrGqcTwdxZn7uFzK6P6HMc/edit?usp=sharing");
    }
}