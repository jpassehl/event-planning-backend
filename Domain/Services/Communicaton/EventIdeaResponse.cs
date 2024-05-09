using EventPlanningAPI.Domain.Models;


namespace EventPlanningAPI.Domain.Services.Communication
{
    public class EventIdeaResponse : BaseResponse
    {
        public EventIdea EventIdea { get; private set; }

        private EventIdeaResponse(bool success, string message, EventIdea eventIdea) : base(success, message)
        {
            EventIdea = eventIdea;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Event Idea">Saved Event Idea.</param>
        /// <returns>Response.</returns>
        public EventIdeaResponse(EventIdea eventIdea) : this(true, string.Empty, eventIdea)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public EventIdeaResponse(string message) : this(false, message, null)
        { }
    }
}
