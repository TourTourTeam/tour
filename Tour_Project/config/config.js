module.exports = {
	server_port: 3000,
	db_url: 'mongodb://localhost:27017/tour',
	db_schemas: [
		{file:'./user_schema', collection:'users', schemaName:'UserSchema', modelName:'UserModel'},
		//{file:'./building_schema', collection:'building', schemaName:'BuildingSchema', modelName:'BuildingModel'},
		//{file:'./map_schema', collection:'map', schemaName:'MapSchema', modelName:'MapModel'},
		//{file:'./parttime_job', collection:'parttime', schemaName:'ParttimeSchema', modelName:'ParttimeModel'} 
	]

	
}