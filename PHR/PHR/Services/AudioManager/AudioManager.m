//
//  AudioManager.m
//  PHR
//
//  Created by Tran Hoang Ha on 9/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AudioManager.h"
#import <AVFoundation/AVFoundation.h>

@implementation AudioManager
+ (AudioManager *)sharedInstance {
    static dispatch_once_t once;
    static AudioManager *sharedInstance;
    dispatch_once(&once, ^{
        sharedInstance = [[AudioManager alloc] init];
    });
    return sharedInstance;
}

- (void)setEnableAudioOutputSpeaker:(BOOL)isEnabled {
    AVAudioSession *session = [AVAudioSession sharedInstance];
    NSError *error;
    [session setCategory:AVAudioSessionCategoryPlayAndRecord error:&error];
    [session setMode:AVAudioSessionModeVoiceChat error:&error];
    if (isEnabled) { // Enable speaker
        [session overrideOutputAudioPort:AVAudioSessionPortOverrideSpeaker error:&error];
    } else { // Disable speaker
        [session overrideOutputAudioPort:AVAudioSessionPortOverrideNone error:&error];
    }
    [session setActive:YES error:&error];
}
@end
