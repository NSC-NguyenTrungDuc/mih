//
//  BodyMeasurementModel.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/25/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@class PHRSample;

@interface BodyMeasurementModel : NSObject

@property (nonatomic, strong) NSString *bodyMeasurementID;
@property (nonatomic, strong) NSString *date;
@property (nonatomic, strong) NSString *note;

@property (nonatomic, strong) NSString *height;
@property (nonatomic, strong) NSString *weight;
@property (nonatomic, strong) NSString *percentFat;
@property (nonatomic, strong) NSString *bmi;
@property (nonatomic, strong) NSString *healthType;
@property (nonatomic) int type;

- (id)initWithBodyMeasurement:(NSString*)height weight:(NSString*)weight percentFat:(NSString*)percentFat bmi:(NSString*)bmi type:(int)type date:(NSString*)date note:(NSString*)note;
+ (instancetype)initWithObj:(NSDictionary *)obj;
- (instancetype)initFromSample:(PHRSample*)sample;
- (void)updateWithDictionary:(NSDictionary*)data;
+ (PHRSample*)sampleFromDict:(NSDictionary*)dict type:(BodyMeasurementType)type;

@end
