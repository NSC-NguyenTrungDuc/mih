package nta.med.service.ihis.handler.adma;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.adm.Adm3500;
import nta.med.core.domain.adm.Adm4200;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3500Repository;
import nta.med.data.dao.medi.adm.Adm4100Repository;
import nta.med.data.dao.medi.adm.Adm4200Repository;
import nta.med.data.model.ihis.adma.ADMS2016MenuInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.CommonModelProto.DataStringListItemInfo;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class ADM103RegSystemFormSaveLayoutHandler extends ScreenHandler<AdmaServiceProto.ADM103RegSystemFormSaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(ADM103RegSystemFormSaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Adm3500Repository adm3500Repository;
	
	@Resource                                                                                                       
	private Adm4200Repository adm4200Repository;
	
	@Resource                                                                                                       
	private Adm4100Repository adm4100Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM103RegSystemFormSaveLayoutRequest request) throws Exception {
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		SystemServiceProto.UpdateResponse.Builder response = saveLayout(request, hospCode, language);
		if(!response.getResult()){
			throw new ExecutionException(response.build());
		}
		return response.build();
	}

	public SystemServiceProto.UpdateResponse.Builder saveLayout(AdmaServiceProto.ADM103RegSystemFormSaveLayoutRequest request, String hospCode, String language){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		adm3500Repository.deleteAdm3500(request.getHospCode(), request.getUserId());
		List<DataStringListItemInfo> listItem = request.getSysIdList();
		List<String> listTemp = adm4200Repository.getMenuByHospCodeAndUserIdAndSysIDs(hospCode, request.getUserId());
		List<String> listTempSub = new ArrayList<>();
		List<String> listItemStr = new ArrayList<>();
		boolean save = false;
		if (!CollectionUtils.isEmpty(listTemp)) {
			for (DataStringListItemInfo info : listItem) {
				listItemStr.add(info.getDataValue());
			}
			for (String s : listItemStr) {
				if(!listTemp.contains(s)){
					listTempSub.add(s);
				}
			}
			for(String sysId : listTempSub){
				List<ADMS2016MenuInfo> listMenuInfo = adm4100Repository.getMenuBySysIDs(sysId, language);
				if (!CollectionUtils.isEmpty(listMenuInfo)) {
					for (ADMS2016MenuInfo item : listMenuInfo) {
						boolean isDupplicateKey = adm4200Repository.isExistedADM4200(hospCode, request.getUserId(), item.getSysId(), item.getTrId());
						if(isDupplicateKey){
							//response.setResult(false);
							//throw new ExecutionException(response.build());
							//List<ADMS2016MenuInfo> listDup = adm4100Repository.getListDup(hospCode, request.getUserId(), item.getSysId(), item.getTrId());
							if(!CollectionUtils.isEmpty(listItem)){
								for(DataStringListItemInfo info : listItem){
									save = insertAdm3500(request, info);
								}
							}	
							
						} else {		
							try {
								Adm4200 adm4200 = new Adm4200();
								adm4200.setUserId(request.getUserId());
								adm4200.setSysId(item.getSysId());
								adm4200.setTrSeq(item.getTrSeq());
								adm4200.setTrId(item.getTrId());
								adm4200.setUpprMenu(item.getUpprMenu());
								adm4200.setCrTime(new Date());
								adm4200.setHospCode(hospCode);
								adm4200Repository.save(adm4200);
							} catch (Exception e) {
								LOGGER.error("Exception when insert into Adm4200: ", e);
							}
						}
					}
				}
			}
		}
		if (!save) {
			if(!CollectionUtils.isEmpty(listItem)){
				for(DataStringListItemInfo item : listItem){
					Adm3500 adm3500 = new Adm3500();
					adm3500.setHospCode(request.getHospCode());
					adm3500.setUserId(request.getUserId());
					adm3500.setSysId(item.getDataValue());
					adm3500.setWorkTime(new Date());
					adm3500Repository.save(adm3500);
				}
			}
			response.setResult(true);
			return response;
		}
		response.setResult(true);
		return response;
	}
	private void insertAdm4200(ADMS2016MenuInfo info, String userId, String hospCode) {
		Adm4200 adm4200 = new Adm4200();
		adm4200.setUserId(userId);
		adm4200.setSysId(info.getSysId());
		adm4200.setTrSeq(info.getTrSeq());
		adm4200.setTrId(info.getTrId());
		adm4200.setUpprMenu(info.getUpprMenu());
		adm4200.setCrTime(new Date());
		adm4200.setHospCode(hospCode);
		adm4200Repository.save(adm4200);
		LOGGER.info(adm4200.toString());
	}
	
	private boolean insertAdm3500(AdmaServiceProto.ADM103RegSystemFormSaveLayoutRequest request, DataStringListItemInfo info) {
		Adm3500 adm3500 = new Adm3500();
		adm3500.setHospCode(request.getHospCode());
		adm3500.setUserId(request.getUserId());
		adm3500.setSysId(info.getDataValue());
		adm3500.setWorkTime(new Date());
		adm3500Repository.save(adm3500);
		return true;
	}
	
}
