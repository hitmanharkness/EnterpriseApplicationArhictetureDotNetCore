(function() {
	$(function() {
		$('#input_apiKey').off();
		$('#input_apiKey').on('change', function() {
			var token = this.value;
			if (token && token.trim() !== '') {
				var headerValue = "Bearer " + token;
				swaggerUi.api.clientAuthorizations.add("auth-header", new SwaggerClient.ApiKeyAuthorization("Authorization", headerValue, "header"));
			}
		});
	});
})();
