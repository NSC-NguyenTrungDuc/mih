//
//  EMRClient.m
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "EMRClient.h"

@implementation EMRClient

#pragma mark - Share Instance
// Share Instance
+ (instancetype)instance {
    static EMRClient *_sharedClient = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        NSString *hostEMR = [[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_EMR"];
        _sharedClient = [[EMRClient alloc] initWithBaseURL:[NSURL URLWithString:hostEMR]];
        [_sharedClient.requestSerializer setValue:@"application/json" forHTTPHeaderField:@"Accept"];
        [_sharedClient.requestSerializer setValue:@"application/json" forHTTPHeaderField:@"Content-Type"];
        _sharedClient.requestSerializer = [AFJSONRequestSerializer serializer];
        //_sharedClient.responseSerializer = [AFJSONResponseSerializer serializer];
        DLog(@"API EMR: %@", hostEMR);
        [_sharedClient.reachabilityManager setReachabilityStatusChangeBlock:^(AFNetworkReachabilityStatus status){
            DLog(@"Reachability Status Changed -> %ld", (long)status);
            [PHRAppDelegate hideLoading];
        }];
        // Check ssl
        if ([hostEMR rangeOfString:@"https"].location != NSNotFound) {
            _sharedClient.securityPolicy = [AFSecurityPolicy defaultPolicy];
            _sharedClient.securityPolicy.allowInvalidCertificates = YES;
            _sharedClient.requestSerializer.timeoutInterval = 120;
        }
    });
    return _sharedClient;
}

- (void)requestGetDetailProgressCourse:(NSString*)hospitalCode andPatientCode:(NSString*)patientCode completion:(void (^)(MFRession *))completion{
    NSString *nameApi = [NSString stringWithFormat:API_GetDetailProgressCourseXML,patientCode,hospitalCode];
    NSLog(@"%@",nameApi);
    [self callWebServicesWithGetApi:nameApi andCompleted:completion];
}

#pragma mark - Public Method

- (void)callWebServicesWithGetApi:(NSString *)nameApi andCompleted:(void (^)(MFRession *))completion {
    [self GET:nameApi parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
        NSDictionary *json = (NSDictionary *)responseObject ;
        MFRession *response = [MFRession responseObjectWithRequestOperation:json error:nil];
        DLog(@"Request -- %@ -- ", task.originalRequest);
        DLog(@"Success -- %@ -- ", response);
        if (completion) {
            completion(response);
        }
    } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
        DLog(@"%@", error.description);
        MFRession *response = [MFRession responseObjectWithRequestOperation:nil error:error];
        if (completion) {
            completion(response);
        }
    }];
}

@end
