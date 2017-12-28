//
//  HealthKitManager.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <HealthKit/HealthKit.h>

@interface HealthKitManager : NSObject

@property (nonatomic, copy) void(^onAuthorizedSuccess)();

+ (HealthKitManager *)sharedManager;

- (void)requestAuthorization;
- (void)startSyncHealthkit;
- (void)writeDataToHealthKitWithType:(NSDictionary*)data withCompletion:(void (^) (BOOL))completeBlock error:(void (^) (NSError*))errorBlock;
- (void)setUpHealthKitBackgroundDelivery;

+ (BOOL)allowRead;
+ (BOOL)allowWrite;
+ (BOOL)allowSyncOn3G;



@end
