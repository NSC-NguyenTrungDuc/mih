package nta.med.service.ihis.handler.adma;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.adm.Adm0100;
import nta.med.core.domain.adm.Adm0200;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.UserRole;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0100Repository;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto.ADM101UGrdGroupItemInfo;
import nta.med.service.ihis.proto.AdmaModelProto.ADM101UgrdSystemItemInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.Date;
import java.util.List;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class ADM101USaveLayoutHandler extends ScreenHandler<AdmaServiceProto.ADM101USaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ADM101USaveLayoutHandler.class);        
	
	@Resource                                                                                                       
	private Adm0100Repository adm0100Repository;
	
	@Resource                                                                                                       
	private Adm0200Repository adm0200Repository;
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	
	@Override
	@Route(global = true)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM101USaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response = saveLayout(request, getLanguage(vertx, sessionId));
		if(!response.getResult()){
			throw new ExecutionException(response.build());
		}
		return response.build();
	} 
	
	public SystemServiceProto.UpdateResponse.Builder saveLayout(AdmaServiceProto.ADM101USaveLayoutRequest request, String language){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<ADM101UGrdGroupItemInfo> listGroupItem = request.getGrdGroupItemList();
		if(!CollectionUtils.isEmpty(listGroupItem)){
			for(ADM101UGrdGroupItemInfo item : listGroupItem){
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					Adm0100 adm0100 = new Adm0100();
					adm0100.setGrpId(item.getGrpId());
					adm0100.setGrpNm(item.getGrpNm());
					adm0100.setGrpSeq(CommonUtils.parseDouble(item.getGrpSeq()));
					adm0100.setDispGrpId(item.getDispGrpId());
					adm0100.setCrMemb(request.getUserId());
					adm0100.setCrTime(new Date());
					adm0100.setLanguage(language);
					adm0100Repository.save(adm0100);
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(adm0100Repository.updateADM101USavePerformerCase1(language, CommonUtils.parseDouble(item.getGrpSeq()), item.getGrpNm(),
							item.getGrpDesc(), item.getDispGrpId(), request.getUserId(), item.getGrpId()) <= 0){
						response.setResult(false);
						return response;
					}
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(adm0100Repository.deleteADM101USavePerformerCase1(language, item.getGrpId()) <= 0 ){
						response.setResult(false);
						return response;
					}
				}
			}
		}
		
		List<ADM101UgrdSystemItemInfo> listSystemItem = request.getGrdSystemItemList();
		if(!CollectionUtils.isEmpty(listSystemItem)){
			for(ADM101UgrdSystemItemInfo item : listSystemItem){
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){					
					boolean isDupplicateKey = adm0200Repository.isExistedADM0200(item.getSysId(), language.toUpperCase());
					if(isDupplicateKey){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}else {				
						Adm0200 adm0200 = new Adm0200();
						adm0200.setGrpId(item.getGrpId());
						adm0200.setSysId(item.getSysId());
						adm0200.setSysNm(item.getSysNm());
						adm0200.setSysSeq(CommonUtils.parseDouble(item.getSysSeq()));
						adm0200.setAdmSysYn(item.getAdmSysYn());
						adm0200.setMsgSysYn(item.getMsgSysYn());
						adm0200.setSysDesc(item.getSysDesc());
						adm0200.setMangDept(item.getMangDept());
						adm0200.setMangDept1(item.getMangDept1());
						adm0200.setCrMemb(request.getUserId());
						adm0200.setCrTime(new Date());
						adm0200.setLanguage(language);
						adm0200Repository.save(adm0200);
						response.setResult(true);
						return response;	
					}
					
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(adm0200Repository.updateADM101USavePerformerCase2(language, item.getGrpId(), item.getSysNm(), item.getAdmSysYn(), item.getMsgSysYn(),
							CommonUtils.parseDouble(item.getSysSeq()), item.getSysDesc(), item.getMangDept(), item.getMangDept1(), request.getUserId(), item.getSysId())<= 0 ){
						response.setResult(false);
						return response;
					}
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(adm0200Repository.deleteADM101USavePerformerCase2(language, item.getSysId()) <= 0 ){
						response.setResult(false);
						return response;
					}
				}
			}
		}
		
		response.setResult(true);
		return response;
	}
}
