//Schema type
//-  String
//-  Number
//-  Date
//-  Buffer
//-  Boolean
//-  Mixed
//-  ObjectId
//-  Array

var Schema = {};


Schema.createSchema = function(mongoose) {
var parttime = mongoose.Schema({
    user_id : { type: String, required:true, 'default':''},
    building_id:{type:String, required:true},
    pay:{type:String,min:0},
    start_time:{type:Date,required:true},
    finish_time:{type:Date,required:true},
});

UserSchema.method('',function(){

});
UserSchema.path();
UserSchema.static();

console.log('UserSchema 정의함.');
return UserSchema;
};


module.exports = Schema;