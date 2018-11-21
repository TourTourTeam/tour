var Schema = {};

Schema.createSchema = function(mongoose) {
var mapSchema = mongoose.Schema({
    id: {type: String, required: true, unique: true},
    schene_name : {type: String, required:true}, //배경 이름
    name : {type: String, required: true}, // 이름 ex) 수성못, schene_name 이랑 합쳐도 될듯 생각해보기
    movement_pay: {type:Number, required: true},// 통행료
});

UserSchema.method('',function(){
    
});
UserSchema.path();
UserSchema.static();

console.log('UserSchema 정의함.');
return UserSchema;
};


module.exports = Schema;