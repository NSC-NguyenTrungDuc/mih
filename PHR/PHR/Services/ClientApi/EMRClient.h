//
//  EMRClient.h
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <AFNetworking/AFNetworking.h>
#import "PHRApiKey.h"

@interface EMRClient : AFHTTPSessionManager
+ (instancetype)instance;
- (void)requestGetDetailProgressCourse:(NSString*)hospitalCode andPatientCode:(NSString*)patientCode completion:(void (^)(MFRession *))completion;
@end
