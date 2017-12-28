package nta.med.service.ihis.handler.adma;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm3200;
import nta.med.core.domain.adm.Adm4200;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.adm.Adm4200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm4100Repository;
import nta.med.data.model.ihis.adma.ADM107ULayDownListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class Adm107ULayRootListHandler extends ScreenHandler<AdmaServiceProto.Adm107ULayRootListRequest, AdmaServiceProto.Adm107ULayRootListResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(Adm107ULayRootListHandler.class); 
	
	@Resource                                                                                                       
	private Adm4100Repository adm4100Repository;

	@Resource
	private Adm4200Repository adm4200Repository;
	@Resource
	private Bas0001Repository bas0001Repository;

	@Resource
	private Adm0200Repository adm0200Repository;

	@Resource
	private Adm3200Repository adm3200Repository;


	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.Adm107ULayRootListRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional
    public AdmaServiceProto.Adm107ULayRootListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.Adm107ULayRootListRequest request) throws Exception {
      	   	AdmaServiceProto.Adm107ULayRootListResponse.Builder response = AdmaServiceProto.Adm107ULayRootListResponse.newBuilder();

		String hospitalCode = request.getHospCode();
		List<Adm4200> adm4200List = adm4200Repository.findByHospCodeAndUserId(hospitalCode, request.getUserId());
		if (CollectionUtils.isEmpty(adm4200List)) {
			List<Adm3200> adm3200List = adm3200Repository.findByHospCodeAndUserId(hospitalCode, request.getUserId());
			if(!CollectionUtils.isEmpty(adm3200List))
			{
				Bas0001 bas0001 = bas0001Repository.getByHospCode(hospitalCode);
				Adm3200 adm3200 = adm3200List.get(0);
				List<ComboListItemInfo> listSystem = adm0200Repository.getLayLogSysList(hospitalCode, bas0001.getLanguage(), adm3200.getUserGroup());
				if (!CollectionUtils.isEmpty(listSystem)) {
					for (ComboListItemInfo combo : listSystem) {
						List<ADM107ULayDownListInfo> adm107ULayDownListInfoList = adm4100Repository.getAdm107uLayDownListInfo(hospitalCode, bas0001.getLanguage(), adm3200.getUserId(), combo.getCode());
						List<ADM107ULayDownListInfo> adm107ULayDownListInfos = new ArrayList<>();
						for (ADM107ULayDownListInfo adm107ULayDownListInfo : adm107ULayDownListInfoList) {
							String trId = adm107ULayDownListInfo.getTrId();
							boolean exist = false;
							for (ADM107ULayDownListInfo info : adm107ULayDownListInfos) {
								if (info.getTrId().equals(trId)) {
									exist = true;
									break;
								}
							}
							if (!exist) {
								adm107ULayDownListInfos.add(adm107ULayDownListInfo);
							}
						}
						for (ADM107ULayDownListInfo adm107ULayDownListInfo : adm107ULayDownListInfos) {
							AdmaModelProto.Adm107USaveLayoutInfo.Builder info = AdmaModelProto.Adm107USaveLayoutInfo.newBuilder();
							info.setUserId(adm3200.getUserId());
							BeanUtils.copyProperties(adm107ULayDownListInfo, info,  getLanguage(vertx, sessionId));
							insertAdm4200(info.build(), hospitalCode);
						}
					}

				}
			}


		}
		List<ADM107ULayDownListInfo> listlayDown = adm4100Repository.getAdm107uLayRootListInfo(request.getHospCode(), getLanguage(vertx, sessionId), request.getUserId(), request.getSysId());
		if(!CollectionUtils.isEmpty(listlayDown)){
			for(ADM107ULayDownListInfo item : listlayDown){
				AdmaModelProto.Adm107ULayDownListInfo.Builder info = AdmaModelProto.Adm107ULayDownListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getTrSeq() != null) {
					info.setTrSeq(String.format("%.0f",item.getTrSeq()));
				}
				response.addLayRootListItem(info);
			}
		}
        return response.build();
	}
	private void insertAdm4200(AdmaModelProto.Adm107USaveLayoutInfo info, String hospitalCode) {
		Adm4200 adm4200 = new Adm4200();
		Double trSeq = CommonUtils.parseDouble(info.getTrSeq());
		adm4200.setHospCode(hospitalCode);
		adm4200.setUserId(info.getUserId());
		adm4200.setSysId(info.getSysId());
		adm4200.setTrId(info.getTrId());
		adm4200.setTrSeq(trSeq);
		adm4200.setUpprMenu(info.getUpprMenu());
		adm4200.setCrMemb(info.getCrMemb());
		adm4200.setCrTime(new Date());
		adm4200Repository.save(adm4200);

	}

}