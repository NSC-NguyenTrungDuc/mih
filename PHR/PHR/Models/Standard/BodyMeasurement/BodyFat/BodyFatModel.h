//
//  BodyFatModel.h
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface BodyFatModel : NSObject

@property (nonatomic, strong) NSString *bodyFatID;
@property (nonatomic) float bodyFat;
@property (nonatomic, strong) NSString *date;
- (id)initWithBodyFat:(float)fat date:(NSString*)date;
+ (instancetype)initBodyFatWithObj:(NSDictionary *)objBodyFat;
- (void)updateWithDictionary:(NSDictionary*)data;
@end
