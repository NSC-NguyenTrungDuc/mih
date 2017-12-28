//
//  EMRDownloadClient.m
//  PHR
//
//  Created by NextopHN on 4/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "EMRDownloadClient.h"

@implementation EMRDownloadClient
#pragma mark - Share Instance
// Share Instance
+ (instancetype)instance {
    static EMRDownloadClient *_sharedClient = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        NSString *hostDownload = [[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_EMR_Download"];
        _sharedClient = [[EMRDownloadClient alloc] initWithBaseURL:[NSURL URLWithString:hostDownload]];
        [_sharedClient.requestSerializer setValue:@"ap" forHTTPHeaderField:@"Content-Type"];
        //_sharedClient.requestSerializer = [AFHTTPRequestSerializer serializer];
        //_sharedClient.responseSerializer = [AFJSONResponseSerializer serializer];
        DLog(@"API Download: %@", hostDownload);
        
        _sharedClient.responseSerializer = [AFJSONResponseSerializer serializer];
        _sharedClient.responseSerializer.acceptableContentTypes = [NSSet setWithObjects:@"image/jpeg", @"image/gif", @"image/png", @"application/pdf", nil];
        
        [_sharedClient.reachabilityManager setReachabilityStatusChangeBlock:^(AFNetworkReachabilityStatus status){
            DLog(@"Reachability Status Changed -> %ld", (long)status);
            [PHRAppDelegate hideLoading];
        }];
        
        if ([hostDownload rangeOfString:@"https"].location != NSNotFound) {
            _sharedClient.securityPolicy = [AFSecurityPolicy defaultPolicy];
            _sharedClient.securityPolicy.allowInvalidCertificates = YES;
            _sharedClient.requestSerializer.timeoutInterval = 120;
        }
    });
    return _sharedClient;
}

- (void)requestDownloadFile:(NSString*)hospitalCode andPatientCode:(NSString*)patientCode andFileName:(NSString*)fileName completion:(void (^)(id))completion{
//    NSString *nameApi = [NSString stringWithFormat:API_GetFileEMR,hospitalCode,patientCode,fileName];
//    [self callWebServicesWithGetApi:nameApi andCompleted:completion];
    [self.requestSerializer setValue:@"1234" forHTTPHeaderField:KEY_Token];
    [self.requestSerializer setValue:@"2" forHTTPHeaderField:@"TRANSFER_TYPE"];
    [self.requestSerializer setValue:hospitalCode forHTTPHeaderField:@"HOSP_CODE"];
    [self.requestSerializer setValue:patientCode forHTTPHeaderField:@"PATIENT_CODE"];
    [self.requestSerializer setValue:fileName forHTTPHeaderField:@"filename"];
    
    
    
    
    
    
    
    [self GET:@"download" parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
        DLog(@"Request -- %@ -- ", task.originalRequest);
        DLog(@"Success -- %@ -- ", responseObject);
        if (completion) {
            completion(responseObject);
        }
    } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
        DLog(@"%@", error.description);
        if (completion) {
            completion(error);
        }
    }];
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
