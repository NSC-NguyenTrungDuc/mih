//
//  MovieTalkConnectionManager.m
//  PHR
//
//  Created by Tran Hoang Ha on 9/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "MovieTalkConnectionManager.h"

@implementation MovieTalkConnectionManager
+ (MovieTalkConnectionManager *)sharedInstance {
    static dispatch_once_t once;
    static MovieTalkConnectionManager *sharedInstance;
    dispatch_once(&once, ^{
        sharedInstance = [[MovieTalkConnectionManager alloc] init];
    });
    return sharedInstance;
}
@end
