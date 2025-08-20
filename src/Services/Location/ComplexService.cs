﻿using SpeedyNET.Abstractions.Contracts.Location;
using SpeedyNET.Abstractions.UserConfigs;
using SpeedyNET.Http.Endpoints.Location;

namespace SpeedyNET.Services.Location;

internal class ComplexService(ILocationEndpoints endpoints)
{
	public async Task<ComplexModel> GetAsync(
		SpeedyAccount account,
		long id,
		CancellationToken ct = default)
	{
		var response = await endpoints.GetComplexAsync(id, new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return response.Complex!.ToModel();
	}

	public async Task<ComplexModel[]> FindAsync(
		SpeedyAccount account,
		int siteId,
		string? name,
		string? type,
		CancellationToken ct = default)
	{
		var response = await endpoints.FindComplexAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			SiteId: siteId,
			Name: name,
			Type: type
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return [.. response.Complexes?.Select(c => c.ToModel()) ?? []];
	}

	public async Task<byte[]> AllAsync(
		SpeedyAccount account,
		int countryId,
		CancellationToken ct = default)
	{
		var response = await endpoints.GetAllComplexesAsync(countryId, new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId
		), ct).ConfigureAwait(false);

		response.EnsureSuccessStatusCode();
		using MemoryStream stream = new();
		await response.Content.CopyToAsync(stream, ct).ConfigureAwait(false);
		return stream.ToArray();
	}
}
