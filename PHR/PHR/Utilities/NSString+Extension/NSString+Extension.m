//
//  NSString+Extension.m
//  PHR
//
//  Created by Luong Le Hoang on 10/20/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "NSString+Extension.h"

@implementation NSString (Extension)

- (BOOL)isEmpty{
    return [self isEqualToString:@""];
}

/*
 * Validate email
 * Return: NO - if wrong format, YES - vice versa
 */
- (BOOL)validateEmail {
    BOOL stricterFilter = NO;
    NSString *stricterFilterString = @"^[_A-Za-z0-9-+]+(\\.[_A-Za-z0-9-+]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z‌​]{2,4})$";
    NSString *laxString = @".+@([A-Za-z0-9-]+\\.)+[A-Za-z]{2}[A-Za-z]*";
    NSString *emailRegex = stricterFilter ? stricterFilterString : laxString;
    NSPredicate *emailPredicate = [NSPredicate predicateWithFormat:@"SELF MATCHES %@", emailRegex];
    return [emailPredicate evaluateWithObject:self];
}

@end
