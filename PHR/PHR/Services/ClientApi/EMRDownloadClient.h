//
//  EMRDownloadClient.h
//  PHR
//
//  Created by NextopHN on 4/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface EMRDownloadClient : AFHTTPSessionManager
+ (instancetype)instance;
- (void)requestDownloadFile:(NSString*)hospitalCode andPatientCode:(NSString*)patientCode andFileName:(NSString*)fileName completion:(void (^)(id))completion;
@end
