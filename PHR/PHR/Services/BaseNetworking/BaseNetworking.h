//
//  BaseNetworking.h
//  PHR
//
//  Created by Tran Hoang Ha on 9/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <Bolts/Bolts.h>
#import <AFNetworking/AFNetworking.h>

@interface BaseNetworking : NSObject
+ (BaseNetworking *)sharedInstance;
@property (nonatomic, strong) AFHTTPSessionManager *manager;
- (BFTask *)fetchRequest:(NSString *)url params:(NSDictionary *)params;
- (BFTask *)putRequest:(NSString *)url params:(NSDictionary *)params;
+ (void)configureNetworkingWithHost:(NSString *)baseUrl;
@end
