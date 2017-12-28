//
//  AudioManager.h
//  PHR
//
//  Created by Tran Hoang Ha on 9/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface AudioManager : NSObject
+ (AudioManager *)sharedInstance;
- (void)setEnableAudioOutputSpeaker:(BOOL)isEnabled;
@end
