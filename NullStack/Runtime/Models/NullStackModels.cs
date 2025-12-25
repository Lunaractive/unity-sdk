using System;
using System.Collections.Generic;

namespace NullStack.Models
{
    [Serializable]
    public class LoginRequest
    {
        public string email;
        public string password;
    }

    [Serializable]
    public class RegisterRequest
    {
        public string email;
        public string password;
        public string username;
    }

    [Serializable]
    public class LoginResponse
    {
        public bool success;
        public LoginData data;
    }

    [Serializable]
    public class LoginData
    {
        public string accessToken;
        public string refreshToken;
        public PlayerData player;
    }

    [Serializable]
    public class PlayerData
    {
        public string id;
        public string email;
        public string username;
        public string titleId;
        public bool isBanned;
        public string createdAt;
    }

    [Serializable]
    public class CloudScriptExecuteRequest
    {
        public string functionName;
        public Dictionary<string, object> args;
    }

    [Serializable]
    public class CloudScriptExecuteResponse
    {
        public bool success;
        public object data;
        public CloudScriptError error;
    }

    [Serializable]
    public class CloudScriptError
    {
        public string code;
        public string message;
    }

    [Serializable]
    public class GetLeaderboardRequest
    {
        public string leaderboardId;
        public int maxResults = 100;
    }

    [Serializable]
    public class LeaderboardResponse
    {
        public bool success;
        public LeaderboardData data;
    }

    [Serializable]
    public class LeaderboardData
    {
        public List<LeaderboardEntry> entries;
        public int total;
    }

    [Serializable]
    public class LeaderboardEntry
    {
        public int position;
        public string playerId;
        public string username;
        public int score;
        public string updatedAt;
    }

    [Serializable]
    public class UpdateLeaderboardRequest
    {
        public string leaderboardId;
        public int score;
    }

    [Serializable]
    public class VirtualCurrencyBalance
    {
        public string currencyCode;
        public int balance;
    }

    [Serializable]
    public class GetPlayerDataResponse
    {
        public bool success;
        public PlayerDataInfo data;
    }

    [Serializable]
    public class PlayerDataInfo
    {
        public string playerId;
        public Dictionary<string, string> data;
    }

    [Serializable]
    public class UpdatePlayerDataRequest
    {
        public Dictionary<string, string> data;
    }

    [Serializable]
    public class CatalogItem
    {
        public string itemId;
        public string displayName;
        public string description;
        public string itemClass;
        public Dictionary<string, int> prices;
        public List<string> tags;
    }

    [Serializable]
    public class PurchaseItemRequest
    {
        public string itemId;
        public string currencyCode;
        public int price;
    }

    [Serializable]
    public class MatchmakingTicketRequest
    {
        public string queueName;
        public Dictionary<string, object> attributes;
    }

    [Serializable]
    public class MatchmakingTicketResponse
    {
        public bool success;
        public MatchmakingTicketData data;
    }

    [Serializable]
    public class MatchmakingTicketData
    {
        public string ticketId;
        public string status;
        public string queueName;
        public string matchId;
        public string createdAt;
    }

    [Serializable]
    public class AnalyticsEvent
    {
        public string eventName;
        public Dictionary<string, object> properties;
    }

    [Serializable]
    public class ErrorResponse
    {
        public bool success;
        public ErrorData error;
    }

    [Serializable]
    public class ErrorData
    {
        public string code;
        public string message;
        public object details;
    }
}

    // Additional Response Models
    [Serializable]
    public class GenericResponse
    {
        public bool success;
        public string message;
    }

    [Serializable]
    public class RegisterResponse
    {
        public bool success;
        public LoginData data;
    }

    [Serializable]
    public class CustomIdLoginRequest
    {
        public string customId;
        public bool createAccount;
        public string titleId;
    }

    [Serializable]
    public class PlayerProfileResponse
    {
        public bool success;
        public PlayerData data;
    }

    [Serializable]
    public class UpdateProfileRequest
    {
        public string displayName;
    }

    [Serializable]
    public class PlayerDataResponse
    {
        public bool success;
        public PlayerDataContainer data;
    }

    [Serializable]
    public class PlayerDataContainer
    {
        public PlayerDataItem[] data;
    }

    [Serializable]
    public class PlayerDataItem
    {
        public string key;
        public string value;
    }

    [Serializable]
    public class UpdatePlayerDataRequest
    {
        public PlayerDataItem[] data;
    }

    [Serializable]
    public class PlayerStatisticsResponse
    {
        public bool success;
        public PlayerStatisticsData data;
    }

    [Serializable]
    public class PlayerStatisticsData
    {
        public StatisticValue[] statistics;
    }

    [Serializable]
    public class StatisticValue
    {
        public string name;
        public int value;
    }

    [Serializable]
    public class StatisticUpdate
    {
        public string name;
        public int value;
    }

    [Serializable]
    public class UpdateStatisticsRequest
    {
        public StatisticUpdate[] statistics;
    }

    [Serializable]
    public class CloudScriptListResponse
    {
        public bool success;
        public CloudScriptListData data;
    }

    [Serializable]
    public class CloudScriptListData
    {
        public string[] functions;
    }

    [Serializable]
    public class CloudScriptHistoryResponse
    {
        public bool success;
        public CloudScriptHistoryData data;
    }

    [Serializable]
    public class CloudScriptHistoryData
    {
        public CloudScriptExecution[] executions;
    }

    [Serializable]
    public class CloudScriptExecution
    {
        public string id;
        public string functionName;
        public string executedAt;
        public object result;
    }

    [Serializable]
    public class UpdateLeaderboardResponse
    {
        public bool success;
        public LeaderboardUpdateData data;
    }

    [Serializable]
    public class LeaderboardUpdateData
    {
        public int position;
        public int value;
    }

    [Serializable]
    public class PlayerRankResponse
    {
        public bool success;
        public PlayerRankData data;
    }

    [Serializable]
    public class PlayerRankData
    {
        public int position;
        public int value;
        public string displayName;
    }

    [Serializable]
    public class PlayerCurrencyResponse
    {
        public bool success;
        public PlayerCurrencyData data;
    }

    [Serializable]
    public class PlayerCurrencyData
    {
        public CurrencyBalance[] currencies;
    }

    [Serializable]
    public class CurrencyBalance
    {
        public string currencyCode;
        public int amount;
    }

    [Serializable]
    public class CurrencyChangeRequest
    {
        public string currencyCode;
        public int amount;
    }

    [Serializable]
    public class CatalogItemsResponse
    {
        public bool success;
        public CatalogItemsData data;
    }

    [Serializable]
    public class CatalogItemsData
    {
        public CatalogItem[] items;
    }

    [Serializable]
    public class PlayerInventoryResponse
    {
        public bool success;
        public PlayerInventoryData data;
    }

    [Serializable]
    public class PlayerInventoryData
    {
        public InventoryItem[] items;
    }

    [Serializable]
    public class InventoryItem
    {
        public string instanceId;
        public string itemId;
        public int quantity;
    }

    [Serializable]
    public class PurchaseItemResponse
    {
        public bool success;
        public PurchaseItemData data;
    }

    [Serializable]
    public class PurchaseItemData
    {
        public string instanceId;
        public int remainingBalance;
    }

    [Serializable]
    public class ConsumeItemRequest
    {
        public string instanceId;
        public int consumeCount;
    }

    [Serializable]
    public class ConsumeItemResponse
    {
        public bool success;
        public ConsumeItemData data;
    }

    [Serializable]
    public class ConsumeItemData
    {
        public int remainingUses;
    }

    [Serializable]
    public class GrantItemRequest
    {
        public string itemId;
    }

    [Serializable]
    public class GrantItemResponse
    {
        public bool success;
        public GrantItemData data;
    }

    [Serializable]
    public class GrantItemData
    {
        public string instanceId;
    }

    [Serializable]
    public class CreateMatchmakingTicketRequest
    {
        public string queueName;
        public Dictionary<string, object> attributes;
    }

    [Serializable]
    public class MatchDetailsResponse
    {
        public bool success;
        public MatchDetailsData data;
    }

    [Serializable]
    public class MatchDetailsData
    {
        public string matchId;
        public string[] playerIds;
        public string status;
    }

    [Serializable]
    public class ActiveMatchesResponse
    {
        public bool success;
        public ActiveMatchesData data;
    }

    [Serializable]
    public class ActiveMatchesData
    {
        public MatchInfo[] matches;
    }

    [Serializable]
    public class MatchInfo
    {
        public string matchId;
        public string status;
        public int playerCount;
    }

    [Serializable]
    public class TrackEventRequest
    {
        public string eventName;
        public Dictionary<string, object> eventData;
    }

    [Serializable]
    public class CustomEventRequest
    {
        public string eventName;
        public string eventType;
        public Dictionary<string, object> properties;
    }

    [Serializable]
    public class PlayerEventsResponse
    {
        public bool success;
        public PlayerEventsData data;
    }

    [Serializable]
    public class PlayerEventsData
    {
        public PlayerEvent[] events;
    }

    [Serializable]
    public class PlayerEvent
    {
        public string eventName;
        public string timestamp;
        public object data;
    }

    [Serializable]
    public class AnalyticsSummaryResponse
    {
        public bool success;
        public AnalyticsSummaryData data;
    }

    [Serializable]
    public class AnalyticsSummaryData
    {
        public int totalEvents;
        public int uniquePlayers;
        public Dictionary<string, int> eventCounts;
    }
}
