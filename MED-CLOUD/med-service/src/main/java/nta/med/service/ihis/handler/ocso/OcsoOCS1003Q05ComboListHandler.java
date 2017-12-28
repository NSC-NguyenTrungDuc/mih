package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsoOCS1003Q05ComboListHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003Q05ComboListRequest, OcsoServiceProto.OcsoOCS1003Q05ComboListResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003Q05ComboListHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003Q05ComboListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003Q05ComboListRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003Q05ComboListResponse.Builder response = OcsoServiceProto.OcsoOCS1003Q05ComboListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		for(CommonModelProto.ComboDataSourceInfo object : request.getCboItemList()){
			if(object.getColName().equalsIgnoreCase("Jusa")){
				// Jusa combobox
				List<ComboListItemInfo> listJusa = ocs0132Repository.getOCS1003Q05JusaComboBox(hospCode, "JUSA", language,"","order");
				if(!CollectionUtils.isEmpty(listJusa)){
					for(ComboListItemInfo item : listJusa){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addJusaCboItem(info);
					}
				}
			}else if(object.getColName().equalsIgnoreCase("Pay")){
				// Pay combobox
				List<ComboListItemInfo> listPay = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "%", "PAY", language);
				if(!CollectionUtils.isEmpty(listPay)){
					for(ComboListItemInfo item : listPay){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addPayCboItem(info);
					}
				}
			}else if(object.getColName().equalsIgnoreCase("Portable_yn")){
				// Portable_yn  combobox
				List<ComboListItemInfo> listPortableYn = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "%", "PORTABLE_YN", language);
				if(!CollectionUtils.isEmpty(listPortableYn)){
					for(ComboListItemInfo item : listPortableYn){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addPortableYnCboItem(info);
					}
				}
			}else if(object.getColName().equalsIgnoreCase("Jusa_spd_gubun")){
				// Jusa_spd_gubun  combobox
				List<ComboListItemInfo> listJusaSpdGubun = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "%", "JUSA_SPD_GUBUN", language);
				if(!CollectionUtils.isEmpty(listJusaSpdGubun)){
					for(ComboListItemInfo item : listJusaSpdGubun){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addJusaSpdGubunCboItem(info);
					}
				}
			}else if(object.getColName().equalsIgnoreCase("Suryang")){
				List<ComboListItemInfo> listSuryang = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "%", "SURYANG", language);
				if(!CollectionUtils.isEmpty(listSuryang)){
					for(ComboListItemInfo item : listSuryang){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addSuryangCboItem(info);
					}
				}
			}else if(object.getColName().equalsIgnoreCase("Nalsu")){
				List<ComboListItemInfo> listNalsu = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "%", "NALSU", language);
				if(!CollectionUtils.isEmpty(listNalsu)){
					for(ComboListItemInfo item : listNalsu){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addNalsuCboItem(info);
					}
				}
			}else if(object.getColName().equalsIgnoreCase("DV")){
				List<ComboListItemInfo> listDv = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "%", "DV", language);
				if(!CollectionUtils.isEmpty(listDv)){
					for(ComboListItemInfo item : listDv){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addDvCboItem(info);
					}
				}
			}
		}
		return response.build();
	}                                                                                                                 
}