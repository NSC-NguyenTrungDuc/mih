package nta.med.service.ihis.handler.ocsa;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.OrderMode;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.data.dao.medi.ocs.Ocs0142Repository;
import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U19TvwJaeryoGubunInfo;
import nta.med.data.model.ihis.system.LoadOftenUsedTabResponseInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CommonModelProto.GetUserOptionInfo;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U19InitializeScreenRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U19InitializeScreenResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U19InitializeScreenHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U19InitializeScreenRequest, OcsaServiceProto.OCS0103U19InitializeScreenResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U19InitializeScreenHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0108Repository cpl0108Repository;                                                                    
	@Resource
	private Bas0270Repository bas0270Repository;
	@Resource
	private Ocs0142Repository ocs0142Repository;
	@Resource
	private Ocs0150Repository ocs0150Repository;                                                                  
	                                                                                                                
	@Override                
	@Transactional(readOnly = true)
	public OCS0103U19InitializeScreenResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U19InitializeScreenRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U19InitializeScreenResponse.Builder response = OcsaServiceProto.OCS0103U19InitializeScreenResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		Date date = new Date();
		SimpleDateFormat dateFormat = new SimpleDateFormat(DateUtil.PATTERN_YYMMDD);
		String sysDate = dateFormat.format(date);
		response.setSysDate(sysDate);
		List<LoadOftenUsedTabResponseInfo> listUserTab = new ArrayList<LoadOftenUsedTabResponseInfo>();
		if(request.getOrderMode().equals(OrderMode.SetOrder.getValue())){
			String name =  bas0270Repository.getLoadColumnCodeNameInfoCaseGwaDoctor(hospCode, "%", request.getMemb(), sysDate);
			if(StringUtils.isEmpty(name)){
				String mainDoctorCode = bas0270Repository.getMainGwaDoctorCodeInfo(hospCode,request.getMemb());
				if(!StringUtils.isEmpty(mainDoctorCode)){
					if(!request.getInputTab().equals("07")){
						listUserTab=ocs0142Repository.getLoadOftenUsedTabInfo(hospCode, language,
								mainDoctorCode, request.getInputTab());
					}else{
						listUserTab = ocs0142Repository.getLoadOftenUsedTabInfoElse(hospCode, language,mainDoctorCode);
					}
				}else{
					if(!request.getInputTab().equals("07")){
						listUserTab=ocs0142Repository.getLoadOftenUsedTabInfo(hospCode, language,
								request.getMemb(), request.getInputTab());
					}else{
						listUserTab = ocs0142Repository.getLoadOftenUsedTabInfoElse(hospCode, language,request.getMemb());
					}
				}
			}
		}else{
			if(request.getUserGubun().equals(request.getDoctor())){
				if(!request.getInputTab().equals("07")){
					listUserTab=ocs0142Repository.getLoadOftenUsedTabInfo(hospCode, language,
							request.getDoctorId(), request.getInputTab());
				}else{
					listUserTab = ocs0142Repository.getLoadOftenUsedTabInfoElse(hospCode, language,request.getDoctorId());
				}
			}else{
				if(!request.getInputTab().equals("07")){
					listUserTab=ocs0142Repository.getLoadOftenUsedTabInfo(hospCode, language,
							request.getUserId(), request.getInputTab());
				}else{
					listUserTab = ocs0142Repository.getLoadOftenUsedTabInfoElse(hospCode, language,request.getUserId());
				}
			}
		}
		
		if(!CollectionUtils.isEmpty(listUserTab)){
			for(LoadOftenUsedTabResponseInfo item : listUserTab){
				CommonModelProto.LoadOftenUsedTabResponseInfo.Builder info = CommonModelProto.LoadOftenUsedTabResponseInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addUsedTabInfo(info);
			} 
		}
		// lay_hangwi_gubun_info 
		List<ComboListItemInfo> listLayHangwi = ocs0142Repository.getOCS0103U19InitializeScreenComboListItem(hospCode, request.getInputTab(),
				"Y", "C", language);
		if(!CollectionUtils.isEmpty(listLayHangwi)){
			for(ComboListItemInfo item : listLayHangwi){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayHangwiGubunInfo(info);
			}
		}
		
		//// TvwJaeryoGubunInfo
		List<OCS0103U19TvwJaeryoGubunInfo> listTvwJaeryoGubunInfo =  ocs0142Repository.getOCS0103U19InitializeScreenTvwJaeryoGubunItem(hospCode,
				 request.getInputTab(), language);
		if(!CollectionUtils.isEmpty(listTvwJaeryoGubunInfo)){
			for(OCS0103U19TvwJaeryoGubunInfo item : listTvwJaeryoGubunInfo){
				OcsaModelProto.OCS0103U19TvwJaeryoGubunInfo.Builder info = OcsaModelProto.OCS0103U19TvwJaeryoGubunInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addTvwJaeryoGubunInfo(info);
			}
		}
		
		if(request.getCodeInfo()!= null){
			String code = OrderBizHelper.getLoadColumnCodeName(hospCode, language, request.getCodeInfo());
			if(!StringUtils.isEmpty(code)){
				response.setCode(code);
			}
		}
		
		if(request.getUserOptionInfo() != null){
			GetUserOptionInfo info = request.getUserOptionInfo();
			String userInfo = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(hospCode,request.getDoctor(),
					info.getGwa(),info.getKeyword(),info.getIoGubun());
			if(!StringUtils.isEmpty(userInfo)){
				response.setUserOption(userInfo);
			}
		}
		
		if(request.getOrderGubunInfo()!= null){
			List<ComboListItemInfo> listOrderGubun = OrderBizHelper.getLoadComboDataSource(hospCode, language, request.getOrderGubunInfo());
			if(!CollectionUtils.isEmpty(listOrderGubun)){
				for(ComboListItemInfo item : listOrderGubun){
					CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addOrderGubunInfo(info);
				}
			}
		}
		if(request.getSuryangInfo()!= null){
			List<ComboListItemInfo> listOrderGubun = OrderBizHelper.getLoadComboDataSource(hospCode, language, request.getSuryangInfo());
			if(!CollectionUtils.isEmpty(listOrderGubun)){
				for(ComboListItemInfo item : listOrderGubun){
					CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addSuryangInfo(info);
				}
			}
		}
		if(request.getNalsuInfo()!= null){
			List<ComboListItemInfo> listOrderGubun = OrderBizHelper.getLoadComboDataSource(hospCode, language, request.getNalsuInfo());
			if(!CollectionUtils.isEmpty(listOrderGubun)){
				for(ComboListItemInfo item : listOrderGubun){
					CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addNalsuInfo(info);
				}
			}
		}
		return response.build();
	}

}