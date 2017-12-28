//
//  MovieTalkConnectionManager.h
//  PHR
//
//  Created by Tran Hoang Ha on 9/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <SkyWay/SKWPeer.h>

@interface MovieTalkConnectionManager : NSObject
+ (MovieTalkConnectionManager *)sharedInstance;
@property (nonatomic, strong) SKWPeer *peer;
@property (nonatomic, strong) SKWMediaConnection *mediaConnection;
@property (nonatomic, strong) SKWDataConnection *dataConnection;
@property (nonatomic, strong) SKWMediaStream *msLocal;
@property (nonatomic, strong) SKWMediaStream *msRemote;
@property (nonatomic, assign) BOOL bConnected;
@end
