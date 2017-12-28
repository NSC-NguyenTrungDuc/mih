//
//  BaseNetworking.m
//  PHR
//
//  Created by Tran Hoang Ha on 9/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BaseNetworking.h"

@implementation BaseNetworking
+ (BaseNetworking *)sharedInstance {
  static dispatch_once_t once;
  static BaseNetworking *sharedInstance;
  dispatch_once(&once, ^{
    sharedInstance = [[BaseNetworking alloc] init];
  });
  return sharedInstance;
}

- (BFTask *)fetchRequest:(NSString *)url params:(NSDictionary *)params {
  BFTaskCompletionSource *taskCompletionSource = [[BFTaskCompletionSource alloc] init];
  [[BaseNetworking sharedInstance].manager GET:url parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id  _Nonnull responseObject) {
    [taskCompletionSource setResult:responseObject];
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    [taskCompletionSource setError:error];
  }];
  return taskCompletionSource.task;
}

- (BFTask *)putRequest:(NSString *)url params:(NSDictionary *)params {
  BFTaskCompletionSource *taskCompletionSource = [[BFTaskCompletionSource alloc] init];
  [[BaseNetworking sharedInstance].manager PUT:url parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id  _Nonnull responseObject) {
    [taskCompletionSource setResult:responseObject];
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    [taskCompletionSource setError:error];
  }];
  return taskCompletionSource.task;
}

+ (void)configureNetworkingWithHost:(NSString *)baseUrl {
  [BaseNetworking sharedInstance].manager = [[AFHTTPSessionManager alloc] initWithBaseURL:[NSURL URLWithString:baseUrl]];
  [[BaseNetworking sharedInstance].manager.requestSerializer setValue:@"application/json" forHTTPHeaderField:@"Accept"];
  [[BaseNetworking sharedInstance].manager.requestSerializer setValue:@"application/json" forHTTPHeaderField:@"Content-Type"];
  [BaseNetworking sharedInstance].manager.requestSerializer = [AFJSONRequestSerializer serializer];
  [[BaseNetworking sharedInstance].manager.reachabilityManager setReachabilityStatusChangeBlock:^(AFNetworkReachabilityStatus status){
    DLog(@"Reachability Status Changed -> %ld", (long)status);
    [PHRAppDelegate hideLoading];
  }];
  // Check ssl
  if ([baseUrl rangeOfString:@"https"].location != NSNotFound) {
    [BaseNetworking sharedInstance].manager.securityPolicy = [AFSecurityPolicy defaultPolicy];
    [BaseNetworking sharedInstance].manager.securityPolicy.validatesDomainName = NO;
    [BaseNetworking sharedInstance].manager.securityPolicy.allowInvalidCertificates = YES;
    [BaseNetworking sharedInstance].manager.requestSerializer.timeoutInterval = 30;
  }
  [BaseNetworking sharedInstance].manager.requestSerializer.timeoutInterval = 30;
}
@end
