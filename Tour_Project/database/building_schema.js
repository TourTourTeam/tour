var Schema = {};

Schema.createSchema = function(mongoose) {
var buildingSchema = mongoose.Schema({
    id: {type: String, required: true, unique: true},
    owner_id:{type:String},
    pos:{x:Number,y:Number,z:Number},
    price:{cur:{type:Number,min:0},
            sale:{type:Number,min:0}
    },
    //upgrade
});

UserSchema.method('',function(){
    
});
UserSchema.path();
UserSchema.static();

console.log('UserSchema 정의함.');
return UserSchema;
};


module.exports = Schema;