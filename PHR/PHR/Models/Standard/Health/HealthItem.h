//
//  HealthItem.h
//  PHR
//
//  Created by Luong Le Hoang on 10/26/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "StandardHealthModel.h"
@interface HealthItem : NSObject {
    
}
@property (nonatomic, strong) NSString *healthId;
@property (strong, nonatomic) NSString *profileId;
@property (nonatomic, strong) NSString *weight;
@property (nonatomic, strong) NSString *height;
@property (nonatomic, strong) NSString *waistLine;
@property (nonatomic, strong) NSString *chestSize;
@property (nonatomic, strong) NSString *lowBloodPress;
@property (nonatomic, strong) NSString *highBloodPress;
@property (nonatomic, strong) NSString *percentageFat;
@property (strong, nonatomic) NSString *bmi;
@property (nonatomic, strong) NSString *note;
@property (nonatomic, strong) NSString *dateRecord;
@property (strong, nonatomic) NSString *dateTime;
//TungNT: new property
@property (strong, nonatomic) NSString *healthType;

+ (instancetype)initHealthWithObj:(NSDictionary *)objHealth;
- (void)updateFromHealth:(HealthItem*)health;
- (void)updateWithDictionary:(NSDictionary*)data;
+ (HealthItem *)initializeHealthFromModel:(StandardHealthModel *)model andDate:(NSString *)date;
@end
