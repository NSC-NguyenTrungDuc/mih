//
//  MFRession.m
//  PHR
//
//  Created by DEV-MinhNN on 11/17/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "MFRession.h"

@implementation MFRession

+ (MFRession *)responseObjectWithRequestOperation:(NSDictionary *)operation error:(NSError *)error {
    NSError *parserError = nil;
    MFRession *obj = [[MFRession alloc] initWithDictionary:operation error:&parserError];
    return obj;
}

@end
