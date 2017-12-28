//
//  MasterDataManager.m
//  PHR
//
//  Created by Luong Le Hoang on 6/2/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "MasterDataManager.h"
#import "MDHeight.h"
#import "MDWeight.h"
#import "MDBMI.h"
#import "MDStepCount.h"
#import "MDHeartRate.h"
#import "MDBloodPressure.h"
#import "MDSleep.h"
#import "MDTemperature.h"
#import "MDBodyFat.h"

static NSString * const kMasterDataManagerSaved = @"kMasterDataManagerSaved";

@implementation MasterDataManager {
    
}

+ (NSArray*)arrayFiles{
    return @[@"heightB", @"heightG", @"weightB", @"weightG", @"bmiB", @"bmiG", @"bloodB", @"bloodG", @"bodyfat", @"heartrateB", @"heartrateG", @"sleep", @"stepB", @"stepG", @"temperature",@""]; // Order as MasterDataType
}

+ (NSString*)fileAtIndex:(NSInteger)index{
    return [self arrayFiles][index];
}

+ (NSInteger)count{
    return 15;
}

+ (RLMRealm*)realm{
    NSString *documentsDirectory = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES)[0];
    NSString *customRealmPath = [documentsDirectory stringByAppendingPathComponent:@"PHRMasterData.realm"]; // /Users/luonglehoang/Library/Developer/CoreSimulator/Devices/9909F59D-D48B-4AEA-8ABB-5D27D3F6051F/data/Containers/Data/Application/90AC79B2-154D-48D0-8B81-DE0E4502B939/Documents/PHRMasterData.realm
    return [RLMRealm realmWithURL:[NSURL fileURLWithPath:customRealmPath]];
//    return [RLMRealm defaultRealm];
}

+ (void)removeMasterData {
    RLMRealm *realm = [self realm];
    [realm beginWriteTransaction]; //4
    [realm deleteAllObjects];
    [realm commitWriteTransaction];
}

+ (void)processData {
    NSString *saved = [[NSUserDefaults standardUserDefaults] objectForKey:kMasterDataManagerSaved];
    DLog(@"BLACK -> check master data saved = %@", saved);
    if (saved && [saved isEqualToString:@"1"]) {
        return;
    }
    [self removeMasterData];
    // Realm
    RLMRealm *realm = [self realm];
    
    [realm beginWriteTransaction];
    // Read data
    NSBundle *bundle = [NSBundle mainBundle];
    NSFileManager *fm = [NSFileManager defaultManager];
    for (NSInteger i = 0; i < [self count] ; i++) {
        NSString *path = [bundle pathForResource:[self fileAtIndex:i] ofType:@"csv"];
        if ([fm fileExistsAtPath:path]) {
            NSString *content = [NSString stringWithContentsOfFile:path encoding:NSUTF8StringEncoding error:nil];
            NSArray *lines = [content componentsSeparatedByCharactersInSet:[NSCharacterSet newlineCharacterSet]];
            for (NSInteger j = 1; j < lines.count; j++) {
                // read data
                NSArray* values = [lines[j] componentsSeparatedByCharactersInSet:[NSCharacterSet characterSetWithCharactersInString:@","]];
                if (i == MasterDataTypeTemperature) {
                    // temperature
                    MDTemperature *tem = [[MDTemperature alloc] init];
                    tem.low = [values[1] doubleValue];
                    tem.normalMin = [values[2] doubleValue];
                    tem.normalMax = [values[3] doubleValue];
                    tem.high = [values[4] doubleValue];
                    tem.mean = (tem.normalMax + tem.normalMin) / 2;
                    [realm addObject:tem];
                }
                else {
                    NSArray *arrAge = [self arrAgeFromRangeString:values[0]];
                    NSInteger minAge = [[arrAge firstObject] integerValue];
                    NSInteger maxAge = [[arrAge lastObject] integerValue];
                    for (NSInteger k = minAge; k <= maxAge; k++) {
                        switch (i) {
                            case MasterDataTypeHeightBoy:
                            case MasterDataTypeHeightGirl:{
                                // height
                                MDHeight *height = [[MDHeight alloc] init];
                                height.gender = i == MasterDataTypeHeightBoy ? MDGenderMale : MDGenderFemale;
                                [height setAgeMeanSdValues:@[@(k), values[1], values[2]]];
                                [realm addObject:height];
                            }
                                break;
                            case MasterDataTypeWeightBoy:
                            case MasterDataTypeWeightGirl:{
                                // weight
                                MDWeight *weight = [[MDWeight alloc] init];
                                weight.gender = i == MasterDataTypeWeightBoy ? MDGenderMale : MDGenderFemale;
                                [weight setAgeMeanSdValues:@[@(k), values[1], values[2]]];
                                 weight.obesity = [values[3] doubleValue];
                                [realm addObject:weight];
                            }
                                break;
                            case MasterDataTypeBmiBoy:
                            case MasterDataTypeBmiGirl:{
                                // BMI
                                MDBMI *bmi = [[MDBMI alloc] init];
                                bmi.gender = i == MasterDataTypeBmiBoy ? MDGenderMale : MDGenderFemale;
                                [bmi setAgeMeanSdValues:@[@(k), values[1], values[2]]];
                                bmi.obesity = [values[3] doubleValue];
                                [realm addObject:bmi];
                            }
                                break;
                            case MasterDataTypeBloodBoy:
                            case MasterDataTypeBloodGirl:{
                                // Blood pressure
                                MDBloodPressure *blood = [[MDBloodPressure alloc] init];
                                blood.age = [@(k) intValue];
                                blood.gender = i == MasterDataTypeBloodBoy ? MDGenderMale : MDGenderFemale;
                                blood.high = [values[1] doubleValue];
                                blood.highSd = [values[2] doubleValue];
                                blood.low = [values[3] doubleValue];
                                blood.lowSd = [values[4] doubleValue];
                                [realm addObject:blood];
                            }
                                break;
                            case MasterDataTypeBodyfat:{
                                // Body fat
                                MDBodyFat *fat = [[MDBodyFat alloc] init];
                                fat.age = [@(k) intValue];
                                fat.low = [values[1] doubleValue];
                                fat.normalMin = [values[2] doubleValue];
                                fat.normalMax = [values[3] doubleValue];
                                fat.high = [values[4] doubleValue];
                                fat.mean = (fat.normalMin + fat.normalMax) /2;
                                [realm addObject:fat];
                            }
                                break;
                            case MasterDataTypeHeartrateBoy:
                            case MasterDataTypeHeartrateGirl:{
                                // heart rate
                                MDHeartRate *rate = [[MDHeartRate alloc] init];
                                rate.gender = i == MasterDataTypeHeartrateBoy ? MDGenderMale : MDGenderFemale;
                                [rate setAgeMeanSdValues:@[@(k), values[1], values[2]]];
                                [realm addObject:rate];
                            }
                                break;
                            case MasterDataTypeSleep:{
                                // sleep
                                MDSleep *sleep = [[MDSleep alloc] init];
                                sleep.age = [@(k) intValue];
                                sleep.min = [values[1] doubleValue];
                                sleep.max = [values[2] doubleValue];
                                [realm addObject:sleep];
                            }
                                break;
                            case MasterDataTypeStepBoy:
                            case MasterDataTypeStepGirl:{
                                // step
                                MDStepCount *step = [[MDStepCount alloc] init];
                                step.gender = i == MasterDataTypeStepBoy ? MDGenderMale : MDGenderFemale;
                                [step setAgeMeanSdValues:@[@(k), values[1], values[2]]];
                                [realm addObject:step];
                            }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
    
    [realm commitWriteTransaction];

    [[NSUserDefaults standardUserDefaults] setObject:@"1" forKey:kMasterDataManagerSaved];
    [[NSUserDefaults standardUserDefaults] synchronize];
    DLog(@"BLACK -> Saved master data");
}

+ (NSArray*)arrAgeFromRangeString:(NSString*)range{
    if ([range containsString:@"_"]) {
        return [range componentsSeparatedByString:@"_"];
    }
    else if ([range containsString:@">"] || [range containsString:@"<"]){
        return @[[range stringByTrimmingCharactersInSet:[NSCharacterSet characterSetWithCharactersInString:@"><"]]];
    }
    return @[range];
}

// rate blood pressure
+ (MasterDataRate)rateBloodPressureLow:(double)low high:(double)high isMen:(BOOL)isMen age:(int)age{
    RLMRealm *realm = [self realm];
    RLMResults *results = [MDBloodPressure objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
    if (results.count <= 0) {
        return MasterDataRateNormal;
    }
    // Get object
    int maxAge = [[results maxOfProperty:@"age"] intValue];
    int minAge = [[results minOfProperty:@"age"] intValue];
    MDBloodPressure *base = nil;
    if (age < minAge){
        base = results[0];
    }
    else if (age > maxAge){
        base = [results lastObject];
    }
    else{
        base = [results objectsWhere:@"age == %d", age][0];
    }
    // compare
    if (low < base.low - base.lowSd || low > base.low + base.lowSd || high < base.high - base.highSd || high > base.high + base.highSd) {
        return MasterDataRateWarning;
    }
    return MasterDataRateNormal;
}

// rate blood pressure
+ (MasterDataRate)rateTemperature:(double)temp {
    RLMRealm *realm = [self realm];
    RLMResults *results = [MDTemperature allObjectsInRealm:realm];
    if (results.count <= 0) {
        return MasterDataRateNormal;
    }
    MDTemperature *result = [results firstObject];
    // compare
    if (temp > result.high || temp < result.low) {
        return MasterDataRateSerious;
    }
    if (temp > result.normalMax || temp < result.normalMin) {
        return MasterDataRateWarning;
    }
    return MasterDataRateNormal;
}

// rate data except blood pressure
+ (MasterDataRate)rateData:(double)data isMen:(BOOL)isMen withType:(MasterDataType)type age:(int)age{
    double max = 0.0, min = 0;
    RLMResults *results = nil;
    RLMRealm *realm = [self realm];
    switch (type) {
        case MasterDataTypeHeightBoy:
        case MasterDataTypeHeightGirl:{
            // height
            results = [MDHeight objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeWeightBoy:
        case MasterDataTypeWeightGirl:{
            // weight
            results = [MDWeight objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeBmiBoy:
        case MasterDataTypeBmiGirl:{
            // BMI
            results = [MDBMI objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeHeartrateBoy:
        case MasterDataTypeHeartrateGirl:{
            // heart rate
            results = [MDHeartRate objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
            
        case MasterDataTypeStepBoy:
        case MasterDataTypeStepGirl:{
            // step
            results = [MDStepCount objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeBodyfat:{
            results = [MDBodyFat objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeSleep:{
            results = [MDSleep objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
       
        default:
            break;
    }
    if (results.count <= 0) {
        return MasterDataRateNormal;
    }
    
    
    // Get object
    int maxAge = [[results maxOfProperty:@"age"] intValue];
    int minAge = [[results minOfProperty:@"age"] intValue];
    MDBase *base = nil;
    if (age < minAge){
        base = results[0];
    }
    else if (age > maxAge){
        base = [results lastObject];
    }
    else{
        base = [results objectsWhere:@"age == %d", age][0];
    }
    
    // Get max/min
    if (type == MasterDataTypeHeightBoy
        || type == MasterDataTypeHeightGirl
        || type == MasterDataTypeWeightBoy
        || type == MasterDataTypeWeightGirl
        || type == MasterDataTypeBmiBoy
        || type == MasterDataTypeBmiGirl
        || type == MasterDataTypeHeartrateBoy
        || type == MasterDataTypeHeartrateGirl
        || type == MasterDataTypeStepBoy
        || type == MasterDataTypeStepGirl){
        max = base.mean + base.sd;
        min = base.mean - base.sd;
    }
    else if (type == MasterDataTypeBodyfat){
        max = ((MDBodyFat*)base).normalMax;
        min = ((MDBodyFat*)base).normalMin;
    }
    else if (type == MasterDataTypeSleep){
        max = ((MDSleep*)base).max;
        min = ((MDSleep*)base).min;
    }
    
    // compare
    if (data < min || data > max) {
        return MasterDataRateWarning;
    }
    return MasterDataRateNormal;
}

+ (float)suggestTimeSleepForAge:(int)age isMen:(BOOL)isMen{
    RLMRealm *realm = [self realm];
    RLMResults* results = [MDSleep objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
    // Get object
    int maxAge = [[results maxOfProperty:@"age"] intValue];
    int minAge = [[results minOfProperty:@"age"] intValue];
    MDSleep *base = nil;
    if (age < minAge){
        base = results[0];
    }
    else if (age > maxAge){
        base = [results lastObject];
    }
    else{
        base = [results objectsWhere:@"age == %d", age][0];
    }
    return base.min;
}

// mean data except blood pressure
+ (double)getMeanData:(BOOL)isMen withType:(MasterDataType)type age:(int)age {
    RLMResults *results = nil;
    RLMRealm *realm = [self realm];
    switch (type) {
        case MasterDataTypeHeightBoy:
        case MasterDataTypeHeightGirl:{
            // height
            results = [MDHeight objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeWeightBoy:
        case MasterDataTypeWeightGirl:{
            // weight
            results = [MDWeight objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeBmiBoy:
        case MasterDataTypeBmiGirl:{
            // BMI
            results = [MDBMI objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeHeartrateBoy:
        case MasterDataTypeHeartrateGirl:{
            // heart rate
            results = [MDHeartRate objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
            
        case MasterDataTypeStepBoy:
        case MasterDataTypeStepGirl:{
            // step
            results = [MDStepCount objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeBodyfat:{
            results = [MDBodyFat allObjectsInRealm:realm];
        }
            break;
        case MasterDataTypeSleep:{
            results = [MDSleep objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeTemperature: {
            results = [MDTemperature allObjectsInRealm:realm];
        }
            break;

        default:
            break;
    }
    if (results.count <= 0) {
        return 0;
    }
    
    // Get object
    int maxAge = [[results maxOfProperty:@"age"] intValue];
    int minAge = [[results minOfProperty:@"age"] intValue];
    MDBase *base = nil;
    if (age < minAge){
        base = results[0];
    }
    else if (age > maxAge){
        base = [results lastObject];
    }
    else{
        base = [results objectsWhere:@"age == %d", age][0];
    }
    return base.mean;
}

// min max data except blood pressure
+ (CGPoint)getMinMaxData:(BOOL)isMen withType:(MasterDataType)type age:(int)age {
    double max = 0.0, min = 0;
    RLMResults *results = nil;
    RLMRealm *realm = [self realm];
    switch (type) {
        case MasterDataTypeHeightBoy:
        case MasterDataTypeHeightGirl:{
            // height
            results = [MDHeight objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeWeightBoy:
        case MasterDataTypeWeightGirl:{
            // weight
            results = [MDWeight objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeBmiBoy:
        case MasterDataTypeBmiGirl:{
            // BMI
            results = [MDBMI objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeHeartrateBoy:
        case MasterDataTypeHeartrateGirl:{
            // heart rate
            results = [MDHeartRate objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
            
        case MasterDataTypeStepBoy:
        case MasterDataTypeStepGirl:{
            // step
            results = [MDStepCount objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeBodyfat:{
            results = [MDBodyFat objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeSleep:{
            results = [MDSleep objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        default:
            break;
    }
    if (results.count <= 0) {
        return CGPointZero;
    }
    
    
    // Get object
    int maxAge = [[results maxOfProperty:@"age"] intValue];
    int minAge = [[results minOfProperty:@"age"] intValue];
    MDBase *base = nil;
    if (age < minAge){
        base = results[0];
    }
    else if (age > maxAge){
        base = [results lastObject];
    }
    else{
        base = [results objectsWhere:@"age == %d", age][0];
    }
    
    // Get max/min
    if (type == MasterDataTypeHeightBoy
        || type == MasterDataTypeHeightGirl
        || type == MasterDataTypeWeightBoy
        || type == MasterDataTypeWeightGirl
        || type == MasterDataTypeBmiBoy
        || type == MasterDataTypeBmiGirl
        || type == MasterDataTypeHeartrateBoy
        || type == MasterDataTypeHeartrateGirl
        || type == MasterDataTypeStepBoy
        || type == MasterDataTypeStepGirl){
        max = base.mean + base.sd;
        min = base.mean - base.sd;
    }
    else if (type == MasterDataTypeBodyfat){
        max = ((MDBodyFat*)base).normalMax;
        min = ((MDBodyFat*)base).normalMin;
    }
    else if (type == MasterDataTypeSleep){
        max = ((MDSleep*)base).max;
        min = ((MDSleep*)base).min;
    }
    
    CGPoint point = CGPointMake(max, min);
    return point;
}

// mean data except blood pressure
+ (CGPoint)getMeanDataBloodPressure:(BOOL)isMen withType:(MasterDataType)type age:(int)age {
    RLMResults *results = nil;
    RLMRealm *realm = [self realm];
    switch (type) {
        case MasterDataTypeBloodBoy:
        case MasterDataTypeBloodGirl:{
            // height
            results = [MDBloodPressure objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        default:
            break;
    }
    if (results.count <= 0) {
        return CGPointZero;
    }
    
    // Get object
    int maxAge = [[results maxOfProperty:@"age"] intValue];
    int minAge = [[results minOfProperty:@"age"] intValue];
    MDBloodPressure *base = nil;
    if (age < minAge){
        base = results[0];
    }
    else if (age > maxAge){
        base = [results lastObject];
    }
    else{
        base = [results objectsWhere:@"age == %d", age][0];
    }
    return CGPointMake(base.high, base.low);
}


+ (CGPoint)getMeanAndSdData:(BOOL)isMen withType:(MasterDataType)type age:(int)age {
    RLMResults *results = nil;
    RLMRealm *realm = [self realm];
    switch (type) {
        case MasterDataTypeHeightBoy:
        case MasterDataTypeHeightGirl:{
            // height
            results = [MDHeight objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeWeightBoy:
        case MasterDataTypeWeightGirl:{
            // weight
            results = [MDWeight objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeBmiBoy:
        case MasterDataTypeBmiGirl:{
            // BMI
            results = [MDBMI objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeHeartrateBoy:
        case MasterDataTypeHeartrateGirl:{
            // heart rate
            results = [MDHeartRate objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
            
        case MasterDataTypeStepBoy:
        case MasterDataTypeStepGirl:{
            // step
            results = [MDStepCount objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeBodyfat:{
            results = [MDBodyFat allObjectsInRealm:realm];
        }
            break;
        case MasterDataTypeSleep:{
            results = [MDSleep objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeTemperature: {
            results = [MDTemperature allObjectsInRealm:realm];
        }
            break;
            
        default:
            break;
    }
    if (results.count <= 0) {
        return CGPointZero;
    }
    
    // Get object
    int maxAge = [[results maxOfProperty:@"age"] intValue];
    int minAge = [[results minOfProperty:@"age"] intValue];
    MDBase *base = nil;
    if (age < minAge){
        base = results[0];
    }
    else if (age > maxAge){
        base = [results lastObject];
    }
    else{
        base = [results objectsWhere:@"age == %d", age][0];
    }
    return CGPointMake(base.mean, base.sd);
}

+ (NSMutableArray*)getMeanDataForBodyFat:(BOOL)isMen age:(int)age {
    NSMutableArray *array = [[NSMutableArray alloc] init];
    RLMRealm *realm = [self realm];
    RLMResults *results =  [MDBodyFat allObjectsInRealm:realm];;
    if (results.count <= 0) {
        return array;
    }
    
    // Get object
    int maxAge = [[results maxOfProperty:@"age"] intValue];
    int minAge = [[results minOfProperty:@"age"] intValue];
    MDBodyFat *base = nil;
    if (age < minAge){
        base = results[0];
    }
    else if (age > maxAge){
        base = [results lastObject];
    }
    else{
        base = [results objectsWhere:@"age == %d", age][0];
    }
    [array addObject:[NSNumber numberWithFloat:base.low]];
    [array addObject:[NSNumber numberWithFloat:base.normalMin]];
    [array addObject:[NSNumber numberWithFloat:base.normalMax]];
    [array addObject:[NSNumber numberWithFloat:base.high]];
    return array;
}

+ (NSMutableArray*)getMeanDataForTemperature:(int)age {
    NSMutableArray *array = [[NSMutableArray alloc] init];
    RLMRealm *realm = [self realm];
    RLMResults *results =  [MDTemperature allObjectsInRealm:realm];;
    if (results.count <= 0) {
        return array;
    }
    
    // Get object
    int maxAge = [[results maxOfProperty:@"age"] intValue];
    int minAge = [[results minOfProperty:@"age"] intValue];
    MDTemperature *base = nil;
    if (age < minAge){
        base = results[0];
    }
    else if (age > maxAge){
        base = [results lastObject];
    }
    else{
        base = [results objectsWhere:@"age == %d", age][0];
    }
    [array addObject:[NSNumber numberWithFloat:base.low]];
    [array addObject:[NSNumber numberWithFloat:base.normalMin]];
    [array addObject:[NSNumber numberWithFloat:base.normalMax]];
    [array addObject:[NSNumber numberWithFloat:base.high]];
    return array;
}

+ (NSMutableArray*)getMeanDataForBloodPressure:(BOOL) isMen age:(int)age {
    NSMutableArray *array = [[NSMutableArray alloc] init];
    RLMResults *results = nil;
    RLMRealm *realm = [self realm];
    
    results = [MDBloodPressure objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
    
    if (results.count <= 0) {
        return array;
    }
    
    // Get object
    int maxAge = [[results maxOfProperty:@"age"] intValue];
    int minAge = [[results minOfProperty:@"age"] intValue];
    MDBloodPressure *base = nil;
    if (age < minAge){
        base = results[0];
    }
    else if (age > maxAge){
        base = [results lastObject];
    }
    else{
        base = [results objectsWhere:@"age == %d", age][0];
    }
    [array addObject:[NSNumber numberWithFloat:base.high]];
    [array addObject:[NSNumber numberWithFloat:base.highSd]];
    [array addObject:[NSNumber numberWithFloat:base.low]];
    [array addObject:[NSNumber numberWithFloat:base.lowSd]];
    return array;
}

+ (NSMutableArray*)getMeanDataForBMIAndWeight:(BOOL) isMen withType:(MasterDataType)type age:(int)age {
    NSMutableArray *array = [[NSMutableArray alloc] init];
    RLMRealm *realm = [self realm];
    RLMResults *results = nil;
    switch (type) {
        case MasterDataTypeWeightBoy:
        case MasterDataTypeWeightGirl:{
            // weight
            results = [MDWeight objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        case MasterDataTypeBmiBoy:
        case MasterDataTypeBmiGirl:{
            // BMI
            results = [MDBMI objectsInRealm:realm where:@"gender == %d", isMen ? MDGenderMale : MDGenderFemale];
        }
            break;
        default:
            break;
    }
    if (results.count <= 0) {
        return array;
    }
    
    // Get object
    int maxAge = [[results maxOfProperty:@"age"] intValue];
    int minAge = [[results minOfProperty:@"age"] intValue];
    MDBMI *base = nil;
    if (age < minAge){
        base = results[0];
    }
    else if (age > maxAge){
        base = [results lastObject];
    }
    else{
        base = [results objectsWhere:@"age == %d", age][0];
    }
    [array addObject:[NSNumber numberWithFloat:base.mean]];
    [array addObject:[NSNumber numberWithFloat:base.sd]];
    [array addObject:[NSNumber numberWithFloat:base.obesity]];
    return array;
}
@end
