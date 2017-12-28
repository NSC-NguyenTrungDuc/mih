package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003Q00cboReserEndTypeGridCellRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003Q00cboReserEndTypeGridCellResponse;

@Service
@Scope("prototype")
public class INP1003Q00cboReserEndTypeGridCellHandler extends 
				ScreenHandler<InpsServiceProto.INP1003Q00cboReserEndTypeGridCellRequest, InpsServiceProto.INP1003Q00cboReserEndTypeGridCellResponse> {

	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1003Q00cboReserEndTypeGridCellResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003Q00cboReserEndTypeGridCellRequest request) throws Exception {
		InpsServiceProto.INP1003Q00cboReserEndTypeGridCellResponse.Builder response = InpsServiceProto.INP1003Q00cboReserEndTypeGridCellResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<ComboListItemInfo> cbo_item        = bas0102Repository.getNuroReceptionTypeList(language, hospCode, "RESER_END_TYPE", true);
		List<ComboListItemInfo> xEditGridCell9  = bas0102Repository.getNuroReceptionTypeList(language, hospCode, "RESER_END_TYPE", false);
		List<ComboListItemInfo> xEditGridCell15 = bas0102Repository.getOcsoOUTSANGU00FindWorker(hospCode, language, "IPWON_MOKJUK");
		List<ComboListItemInfo> xEditGridCell16 = bas0102Repository.getOcsoOUTSANGU00FindWorker(hospCode, language, "IPWON_RTN2");
		List<ComboListItemInfo> xEditGridCell17 = bas0102Repository.getOcsoOUTSANGU00FindWorker(hospCode, language, "SOGYE_YN");
		List<ComboListItemInfo> xEditGridCell19 = bas0102Repository.getAdmMesgListItemInfo(language, hospCode, "HOPE_ROOM");
		
		if(CollectionUtils.isEmpty(cbo_item) || CollectionUtils.isEmpty(xEditGridCell9) || CollectionUtils.isEmpty(xEditGridCell15) || CollectionUtils.isEmpty(xEditGridCell16) ||
				CollectionUtils.isEmpty(xEditGridCell17) || CollectionUtils.isEmpty(xEditGridCell19)){
			return response.build();
		}
		//cbo_item
		for (ComboListItemInfo info : cbo_item) {
			CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addCboItem(infoProto);
		}
		//xEditGridCell9
		for (ComboListItemInfo info : xEditGridCell9) {
			CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addXEditGridCell9(infoProto);
		}
		//xEditGridCell15
		for (ComboListItemInfo info : xEditGridCell15) {
			CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addXEditGridCell15(infoProto);
		}
		//xEditGridCell16
		for (ComboListItemInfo info : xEditGridCell16) {
			CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addXEditGridCell16(infoProto);
		}
		//xEditGridCell17
		for (ComboListItemInfo info : xEditGridCell17) {
			CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addXEditGridCell17(infoProto);
		}
		//xEditGridCell19
		for (ComboListItemInfo info : xEditGridCell19) {
			CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addXEditGridCell19(infoProto);
		}		
		
		return response.build();
	}


}
