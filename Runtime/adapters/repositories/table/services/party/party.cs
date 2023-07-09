
using System;
using System.IO;
using System.Threading.Tasks;
using adapters.utils.httpClient;
using models;
using models.dto;
using models.inputs;
using models.outputs;
using Newtonsoft.Json;
using ports;
using UnityEngine;

namespace adapters.repositories.table.services.party
{
    public class PartyRepository:IPartyRepository
    {

        public PartyRepository()
        {
        }

        public async Task<RowListResponse<Party>> GetParties<T>(T input) where T : GetPartiesParams
        {
            var response = await WebRequest.Get(UrlMap.GetPartiesUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Party>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);

        }

        public async Task<RowResponse<Party>> CreateParty<T>(T input) where T : CreatePartyParams
        {
            var response = await WebRequest.Post(UrlMap.CreatePartyUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Party>>(await reader.ReadToEndAsync());

            Debug.Log(await reader.ReadToEndAsync());
            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowListResponse<Party>> GetSubscribedParties<T>(T input) where T : GetSubscribedPartiesParams
        {
            var response = await WebRequest.Get(UrlMap.GetSubscribedPartiesUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Party>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<Party>> GetPartyById<T>(T input) where T : GetPartyByIdParams
        {
            var response = await WebRequest.Get(UrlMap.GetPartyByIdUrl(input.PartyId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Party>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<PartyMember>> JoinToParty<T>(T input) where T : JoinToPartyParams
        {
            var response = await WebRequest.Post(UrlMap.JoinToPartyUrl(input.PartyId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<PartyMember>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<Party>> EditParty<T>(T input) where T : EditPartyParams
        {
            var response = await WebRequest.Put(UrlMap.EditPartyUrl(input.PartyId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Party>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<ActionResponse> LeaveParty<T>(T input) where T : LeavePartyParams
        {
            var response = await WebRequest.Delete(UrlMap.LeavePartyUrl(input.PartyId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ActionResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowListResponse<RichPartyMember>> GetPartyMembers<T>(T input) where T : GetPartyMembersParams
        {
            var response = await WebRequest.Get(UrlMap.GetPartyMembersUrl(input.PartyId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<RichPartyMember>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowListResponse<PartyMember>> GetPartyWaitingMembers<T>(T input) where T : GetPartyWaitingMembersParams
        {
            var response = await WebRequest.Get(UrlMap.GetPartyWaitingMembersUrl(input.PartyId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<PartyMember>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<PartyMember>> AcceptJoining<T>(T input) where T : AcceptJoiningParams
        {
            var response = await WebRequest.Put(UrlMap.AcceptJoiningUrl(input.PartyId, input.MembershipId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<PartyMember>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<PartyMember>> RejectJoining<T>(T input) where T : RejectJoiningParams
        {
            var response = await WebRequest.Delete(UrlMap.RejectJoiningUrl(input.PartyId, input.MembershipId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<PartyMember>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }
    }
}