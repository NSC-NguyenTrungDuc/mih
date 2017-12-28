package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0208Q00LayBanghyangInfo;
import nta.med.data.model.ihis.ocsa.OCS0208Q00LayTabGubunInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0208Q00CommonDataRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0208Q00CommonDataResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0208Q00CommonDataHandler
	extends ScreenHandler<OcsaServiceProto.OCS0208Q00CommonDataRequest, OcsaServiceProto.OCS0208Q00CommonDataResponse> {                     
	@Resource                                                                                                       
	private Inv0102Repository inv0102Repository;     
	@Resource
	private Drg0120Repository drg0120Repository;
	                                                                                                                
	@Override             
	@Transactional(readOnly = true)
	public OCS0208Q00CommonDataResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0208Q00CommonDataRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0208Q00CommonDataResponse.Builder response = OcsaServiceProto.OCS0208Q00CommonDataResponse.newBuilder();   
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		// LoadComboDataSource: dv_time
		CommonModelProto.ComboDataSourceInfo dvTimeInfo=request.getDvTimeInfo();
		if(dvTimeInfo!=null){
			List<ComboListItemInfo> listDvTime=OrderBizHelper.getLoadComboDataSource(hospCode, language, dvTimeInfo);
			if(!CollectionUtils.isEmpty(listDvTime)){
				for(ComboListItemInfo item:listDvTime){
					CommonModelProto.ComboListItemInfo.Builder info=CommonModelProto.ComboListItemInfo.newBuilder();
					 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					 response.addDvTimeInfo(info);
				}
			}
		}
		// LoadComboDataSource: dv
		CommonModelProto.ComboDataSourceInfo dvInfo=request.getDvInfo();
		if(dvInfo!=null){
			List<ComboListItemInfo> listDv=OrderBizHelper.getLoadComboDataSource(hospCode, language, dvInfo);
			if(!CollectionUtils.isEmpty(listDv)){
				for(ComboListItemInfo item:listDv){
					CommonModelProto.ComboListItemInfo.Builder info=CommonModelProto.ComboListItemInfo.newBuilder();
					 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					 response.addDvInfo(info);
				}
			}
		}
		// layTabGubun
		List<OCS0208Q00LayTabGubunInfo> listLayTab=inv0102Repository.getOCS0208Q00LayTabGubunInfo(hospCode, language);
		if(!CollectionUtils.isEmpty(listLayTab)){
			for(OCS0208Q00LayTabGubunInfo item: listLayTab){
				OcsaModelProto.OCS0208Q00LayTabGubunInfo.Builder info=OcsaModelProto.OCS0208Q00LayTabGubunInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addTabGubunItemList(info);
			}
		}
		// layBanghyang
		if(!StringUtils.isEmpty(request.getBogyongCode())){
			List<OCS0208Q00LayBanghyangInfo> getLayBangHyang=drg0120Repository.getOCS0208Q00LayBanghyangInfo(hospCode,request.getBogyongCode(), language);
			if(!CollectionUtils.isEmpty(getLayBangHyang)){
				for(OCS0208Q00LayBanghyangInfo item: getLayBangHyang){
					OcsaModelProto.OCS0208Q00LayBanghyangInfo.Builder info=OcsaModelProto.OCS0208Q00LayBanghyangInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addBanghyangItemList(info);
				}
			}
		}
		return response.build();
	}	
}