package nta.med.service.ihis.handler.ocso;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CommonModelProto.ComboDataSourceInfo;
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
public class OCS1003Q09LoadComboDataSourceHandler extends ScreenHandler<OcsoServiceProto.OCS1003Q09LoadComboDataSourceRequest, OcsoServiceProto.OCS1003Q09LoadComboDataSourceResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003Q09LoadComboDataSourceHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0108Repository cpl0108Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public OcsoServiceProto.OCS1003Q09LoadComboDataSourceResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003Q09LoadComboDataSourceRequest request) throws Exception {
		OcsoServiceProto.OCS1003Q09LoadComboDataSourceResponse.Builder response = OcsoServiceProto.OCS1003Q09LoadComboDataSourceResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<ComboDataSourceInfo> listInput = new ArrayList<ComboDataSourceInfo>();
		listInput.add(request.getForColPay());
		listInput.add(request.getForJusaSpdGubun());
		listInput.add(request.getForPortableYn());
		if(!CollectionUtils.isEmpty(listInput)){
			for(ComboDataSourceInfo inputInfo : listInput){
				List<ComboListItemInfo> list = OrderBizHelper.getLoadComboDataSource(hospCode, language, inputInfo);
				if(!CollectionUtils.isEmpty(list)){
					for(ComboListItemInfo item : list){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						if(inputInfo.getColName().equals("pay")){
							response.addDataForColPay(info);
						}else if(inputInfo.getColName().equals("portable_yn")){
							response.addDataForPortableYn(info);
						}
					}
				}
			}
		}
		//get ComboListItemInfo case Nalsu
		List<ComboListItemInfo> listNalsu  = OrderBizHelper.getLoadComboDataSource(hospCode, language, request.getForNalsu());
		if(!CollectionUtils.isEmpty(listNalsu)){
			for(ComboListItemInfo item : listNalsu){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDataForNalsu(info);
			}
		}
		//get ComboListItemInfo case suryang 
		List<ComboListItemInfo> listSuryang  = OrderBizHelper.getLoadComboDataSource(hospCode, language, request.getForSuryang());
		if(!CollectionUtils.isEmpty(listSuryang)){
			for(ComboListItemInfo item : listSuryang){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDataForSuryang(info);
			}
		}
		//get ComboListItemInfo case dv  
		List<ComboListItemInfo> listDv  = OrderBizHelper.getLoadComboDataSource(hospCode, language, request.getForDv());
		if(!CollectionUtils.isEmpty(listDv)){
			for(ComboListItemInfo item : listDv){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDataForDv(info);
			}
		}
		return response.build();
	}                                                                                                                 
}