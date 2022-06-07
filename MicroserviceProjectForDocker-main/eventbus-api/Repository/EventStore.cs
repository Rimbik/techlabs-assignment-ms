using api.Model;

namespace eventbus_api.Repository
{
    public static class EventStore
    {
        public static List<Blog> eventSource = new List<Blog>();
        public static Dictionary<string, string> eventComments = new Dictionary<string, string>();
        public static bool SaveEvent(string key, string post)
        {
            eventSource.Add(new Blog() { BlogID = key, BlogMessage = post });

            return true;
        }

        public static bool SaveComment(string key, string post)
        {
            var getBloag = eventSource.FirstOrDefault(e => e.BlogID == key);
                        
            if (getBloag == null)
            {
                eventSource.Add(new Blog() { BlogID = key });
            }
            
            getBloag = eventSource.FirstOrDefault(e => e.BlogID == key);
            if (getBloag != null)
            {
                if (getBloag.Comments == null)
                    getBloag.Comments = new List<string>();
             
                getBloag.Comments.Add(post);
            }
            return true;
        }

        public static List<Blog> GetAllEvents()
        {
            return eventSource;
        }
    }
}
