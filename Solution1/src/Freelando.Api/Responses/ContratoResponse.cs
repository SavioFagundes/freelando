﻿using Freelando.Modelos;

namespace Freelando.Api.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia Vigencia);