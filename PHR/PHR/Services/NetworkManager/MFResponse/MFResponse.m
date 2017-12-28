//
//  MFResponse.m
//  PHR
//
//  Created by DEV-MinhNN on 11/12/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "MFResponse.h"

@implementation MFResponse

+ (MFResponse *)responseObjectWithRequestOperation:(NSDictionary *)operation
                                                   error:(NSError *)error {
    NSError *parserError = nil;
    MFResponse *obj = [[MFResponse alloc] initWithDictionary:operation error:&parserError];
    return obj;
}

@end
