package nta.med.service.ihis.handler.clis;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.clis.ClisProtocol;
import nta.med.core.domain.clis.ClisProtocolStatus;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.clis.ClisProtocolPatientRepository;
import nta.med.data.dao.medi.clis.ClisProtocolRepository;
import nta.med.data.dao.medi.clis.ClisProtocolStatusRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto.CLIS2015U02GrdProtocolInfo;
import nta.med.service.ihis.proto.ClisModelProto.CLIS2015U02GrdStatusInfo;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U02SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CLIS2015U02SaveLayoutHandler extends ScreenHandler<CLIS2015U02SaveLayoutRequest, UpdateResponse> {
	@Resource
	private ClisProtocolRepository clisProtocolRepository;
	
	@Resource
	private ClisProtocolPatientRepository clisProtocolPatientRepository;
	
	@Resource
	private ClisProtocolStatusRepository clisProtocolStatusRepository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CLIS2015U02SaveLayoutRequest request)
			throws Exception {
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		boolean save = false;
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		Integer clisSmoId = getClisSmoId(vertx, sessionId);
		
		if(request.getGrdProtocolList() != null){
			CLIS2015U02GrdProtocolInfo item = request.getGrdProtocolList();
			if(item.getRowState().equals(DataRowState.ADDED.getValue())){
				List<String> listCode = clisProtocolRepository.validateInsertProtocolCode(item.getProtocolCode(), hospCode) ;
				if(!CollectionUtils.isEmpty(listCode)){
					response.setResult(false);
					response.setMsg("CMO_M002");
					throw new ExecutionException(response.build());
				}
				
				Date startDate = DateUtil.toDate(item.getFromDate(), DateUtil.PATTERN_YYMMDD);
				Date endDate = DateUtil.toDate(item.getToDate(), DateUtil.PATTERN_YYMMDD);
				if(endDate.before(startDate)){
					response.setResult(false);
					response.setMsg("CMO_M010");
					throw new ExecutionException(response.build());
				}
				
				ClisProtocol clisProtocol = new ClisProtocol();
				clisProtocol.setClisSmoId(clisSmoId);
				clisProtocol.setProtocolCode(item.getProtocolCode());
				clisProtocol.setProtocolName(item.getProtocolName());
				clisProtocol.setStartDate(startDate);
				clisProtocol.setEndDate(endDate);
				clisProtocol.setStatusFlg(item.getProtocolStatus());
				clisProtocol.setDescription(item.getDescription());
				clisProtocol.setHospCode(hospCode);
				clisProtocol.setActiveFlg(new BigDecimal(1));
				clisProtocol.setResource(item.getResource());
				clisProtocol.setSysId(userId);
				clisProtocol.setUpdId(userId);
				java.util.Date date = new java.util.Date();
				clisProtocol.setCreated(new Timestamp(date.getTime()));
				clisProtocol.setUpdated(new Timestamp(date.getTime()));
				clisProtocolRepository.save(clisProtocol);
				
				if(!CollectionUtils.isEmpty(request.getGrdStatusListList())){
					for(CLIS2015U02GrdStatusInfo statusItem : request.getGrdStatusListList()){
						insertClisProtocolStatus(statusItem, clisProtocol.getClisProtocolId().intValue(), userId);
					}
				}
			}else if(item.getRowState().equals(DataRowState.MODIFIED.getValue())){
				List<String> listCode = clisProtocolRepository.validateProtocolCode(item.getProtocolCode(), hospCode,CommonUtils.parseLong(item.getProtocolId())) ;
				if(!CollectionUtils.isEmpty(listCode)){
					response.setResult(false);
					response.setMsg("CMO_M002");
					throw new ExecutionException(response.build());
				}
				//
				Date startDate = DateUtil.toDate(item.getFromDate(), DateUtil.PATTERN_YYMMDD);
				Date endDate = DateUtil.toDate(item.getToDate(), DateUtil.PATTERN_YYMMDD);
				if(endDate.before(startDate)){
					response.setResult(false);
					response.setMsg("CMO_M010");
					throw new ExecutionException(response.build());
				}
				//
				updateClisProtocol(item, hospCode, userId);
			}else if(item.getRowState().equals(DataRowState.DELETED.getValue())){
				if(clisProtocolPatientRepository.countPatient(CommonUtils.parseInteger(item.getProtocolId()), hospCode) > 0){
					response.setResult(false);
					response.setMsg("CMO_M003");
					throw new ExecutionException(response.build());
				}
				deleteClisProtocol(item, hospCode, userId);
			}
		}
		
		if(!CollectionUtils.isEmpty(request.getGrdStatusListList())){					
			for(CLIS2015U02GrdStatusInfo statusItem : request.getGrdStatusListList()){
				if(statusItem.getRowState().equals(DataRowState.MODIFIED.getValue())){
					updateClisProtocolStatus(statusItem, userId);
				}
			}
			
		}
		save = true;
		response.setResult(save);
		return response.build();
	}
	
	
	private void insertClisProtocolStatus(CLIS2015U02GrdStatusInfo item,Integer clisProtocolId, String userId){
		ClisProtocolStatus clisProtocolStatus = new ClisProtocolStatus();
		clisProtocolStatus.setClisProtocolId(clisProtocolId);
		clisProtocolStatus.setSortNo(CommonUtils.parseInteger(item.getSortNo()));
		if(!StringUtils.isEmpty(item.getDisplayFlg())){
			clisProtocolStatus.setDisplayFlg(item.getDisplayFlg());
		}else{
			clisProtocolStatus.setDisplayFlg("N");
		}
		clisProtocolStatus.setActiveFlg(new BigDecimal(1));
		clisProtocolStatus.setCode(item.getStatusCode());
		clisProtocolStatus.setSysId(userId);
		clisProtocolStatusRepository.save(clisProtocolStatus);
	}
	
	private void updateClisProtocol(CLIS2015U02GrdProtocolInfo item, String hospCode, String userId){
		ClisProtocol clisProtocol = clisProtocolRepository.findOne(CommonUtils.parseLong(item.getProtocolId()));
		clisProtocol.setProtocolCode(item.getProtocolCode());
		clisProtocol.setProtocolName(item.getProtocolName());
		clisProtocol.setStartDate(DateUtil.toDate(item.getFromDate(), DateUtil.PATTERN_YYMMDD));
		clisProtocol.setEndDate(DateUtil.toDate(item.getToDate(), DateUtil.PATTERN_YYMMDD));
		clisProtocol.setStatusFlg(item.getProtocolStatus());
		clisProtocol.setDescription(item.getDescription());
		clisProtocol.setResource(item.getResource());
		clisProtocol.setUpdId(userId);
		java.util.Date date = new java.util.Date();
		clisProtocol.setUpdated(new Timestamp(date.getTime()));
		clisProtocolRepository.save(clisProtocol);
	}
	
	private void deleteClisProtocol(CLIS2015U02GrdProtocolInfo item, String hospCode, String userId){
		ClisProtocol clisProtocol = clisProtocolRepository.findOne(CommonUtils.parseLong(item.getProtocolId()));
		clisProtocol.setActiveFlg(new BigDecimal(0));
		clisProtocol.setUpdId(userId);
		java.util.Date date = new java.util.Date();
		clisProtocol.setUpdated(new Timestamp(date.getTime()));
		clisProtocolRepository.save(clisProtocol);
	}
	
	private void updateClisProtocolStatus(CLIS2015U02GrdStatusInfo item, String userId){
		ClisProtocolStatus clisProtocolStatus = clisProtocolStatusRepository.findOne(CommonUtils.parseLong(item.getStatusId()));
		clisProtocolStatus.setClisProtocolId(CommonUtils.parseInteger(item.getProtocolId()));
		clisProtocolStatus.setSortNo(CommonUtils.parseInteger(item.getSortNo()));
		clisProtocolStatus.setDisplayFlg(item.getDisplayFlg());
		clisProtocolStatus.setUpdId(userId);
		java.util.Date date = new java.util.Date();
		clisProtocolStatus.setUpdated(new Timestamp(date.getTime()));
		clisProtocolStatusRepository.save(clisProtocolStatus);
	}
}
