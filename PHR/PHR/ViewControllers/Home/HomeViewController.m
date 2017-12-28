//
//  HomeViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/21/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "HomeViewController.h"
#import <AVKit/AVKit.h>
#import <AVFoundation/AVFoundation.h>

@interface HomeViewController (){
    AVPlayerViewController *_moviePlayer;
}

@end

@implementation HomeViewController

- (void)viewDidLoad {
    [super viewDidLoad];
   // [self setNeedsStatusBarAppearanceUpdate];
    self.labelPersonal.text = kLocalizedString(kHealthCare);
    self.labelHealth.text = kLocalizedString(kRecorder);
    self.labelRecord.text = kLocalizedString(konKCCK);
    self.labelAProductOf.text = kLocalizedString(kAProductOfKarteClinic);
    [self.btnRegister setTitle:kLocalizedString(kGetStart) forState:UIControlStateNormal];
    [self.btnRegister setBackgroundColor:[UIColor colorWithRed:36.0/255.0 green:176.0/255.0 blue:153.0/255.0 alpha:0.9]];
    [self.btnSignIn setTitle:kLocalizedString(kHaveAnAccount) forState:UIControlStateNormal];
    [self.btnSignIn setBackgroundColor:[UIColor colorWithRed:0 green:0 blue:0 alpha:0.45]];
    //self.btnPlayVideo.enabled = NO;
    
    NSString *sleepTime = [NSUtils valueForKey:kNotifyLongTimeComeBackApp];
    if(sleepTime != nil) {
        NSDate *startDate  = [UIUtils dateFromString:sleepTime withFormat:@"hh:mm:ss a yyyy/MM/dd"];
        NSDate *currenDate = [NSDate date];
        DLog(@"StartTime:%@",sleepTime);
        NSInteger seconds = [currenDate timeIntervalSinceDate:startDate];
        DLog(@"second:%ld",seconds)
        if (seconds > PHR_TIME_REOPEN_APP) {
            [NSUtils showMessage:kLocalizedString(kLongTimeNoSee) withTitle:APP_NAME];
        }
    }
    [NSUtils removeObjectForKey:kNotifyLongTimeComeBackApp];
    NSString *saveSleepTime = [UIUtils stringDate:[NSDate date] withFormat:@"hh:mm:ss a yyyy/MM/dd"];
    [NSUtils setValue:saveSleepTime forKey:kNotifyLongTimeComeBackApp];
    [self autoSignInApplication];
    
//    // video player
//    _moviePlayer = [[AVPlayerViewController alloc] init];
//    _moviePlayer.view.frame = self.viewPlayer.frame;
//    [self.viewPlayer addSubview:_moviePlayer.view];
//    [_moviePlayer.view autoPinEdgeToSuperviewEdge:ALEdgeLeading];
//    [_moviePlayer.view autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
//    [_moviePlayer.view autoPinEdgeToSuperviewEdge:ALEdgeTop];
//    [_moviePlayer.view autoPinEdgeToSuperviewEdge:ALEdgeBottom];
//    _moviePlayer.view.userInteractionEnabled = NO;
//    _moviePlayer.showsPlaybackControls = NO;
//    [_moviePlayer setVideoGravity:AVLayerVideoGravityResizeAspectFill];
//    // Play video
//    NSURL *videoURL = [[NSBundle mainBundle]URLForResource:@"Karte_Intro" withExtension:@"mp4"];
//    _moviePlayer.player = [AVPlayer playerWithURL:videoURL];
//    [_moviePlayer.player play];
//    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(playerItemDidReachEnd) name:AVPlayerItemDidPlayToEndTimeNotification object:nil];
//    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(playerItemDidReachEnd) name:UIApplicationWillEnterForegroundNotification object:nil];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    
}

- (void)autoSignInApplication {
    NSString *username = [NSUtils valueForKey:PHRJNKeyChainEmail];
    NSString *password = [NSUtils valueForKey:PHRJNKeyChainPass];
    NSString *facebookAccessToken = [NSUtils valueForKey:PHRJNKeyChainFacebookAccessToken];
    
    //Auto login with facebook
    if (![UIUtils isNullOrEmpty:facebookAccessToken]) {
        [self requestLoginWithFacebook:facebookAccessToken isAutologin:true];
        return;
    }
    
    if (![UIUtils isNullOrEmpty:username] && ![UIUtils isNullOrEmpty:password]) {
        [self requestLoginWithEmail:username password:password];
    }
}

- (IBAction)pressBtnRegister:(id)sender {
    SignUpViewController *controllerPreLogin = [[SignUpViewController alloc] initWithNibName:NSStringFromClass([SignUpViewController class]) bundle:nil];
    [self.navigationController pushViewController:controllerPreLogin animated:YES];
}

- (IBAction)pressBtnSignIn:(id)sender {
    SignInViewController *controllerPreLogin = [[SignInViewController alloc] initWithNibName:NSStringFromClass([SignInViewController class]) bundle:nil];
    [self.navigationController pushViewController:controllerPreLogin animated:YES];
}

- (void)playerItemDidReachEnd {
    if (_moviePlayer.player){
        [_moviePlayer.player seekToTime:kCMTimeZero];
        [_moviePlayer.player play];
    }
}

-(void) playVideo{
    [_moviePlayer.player play];
}

-(void) pauseVideo {
    [_moviePlayer.player pause];
}

- (UIStatusBarStyle) preferredStatusBarStyle {
    return UIStatusBarStyleDefault;
}

@end
