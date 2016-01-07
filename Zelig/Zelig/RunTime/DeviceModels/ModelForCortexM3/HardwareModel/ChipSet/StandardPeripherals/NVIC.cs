//
// Copyright (c) Microsoft Corporation.    All rights reserved.
//

namespace Microsoft.DeviceModels.Chipset.CortexM3
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Microsoft.Zelig.Runtime.TargetPlatform.ARMv7;

    using RT = Microsoft.Zelig.Runtime;

    //--//

    // TODO: put right addresses, and fix code generation for LLVM that does not understand the attribute's constants
    //[MemoryMappedPeripheral(Base = 0x40D00000U, Length = 0x000000D0U)]
    public class NVIC
    {
        
        //////
        //////	From core_cm3.h in mBed CMSIS support: 
        //////        
        //////  /** \brief  Structure type to access the Nested Vectored Interrupt Controller (NVIC).
        //////   */
        //////  typedef struct
        //////  {
        //////    __IO uint32_t ISER[8];                 /*!< Offset: 0x000 (R/W)  Interrupt Set Enable Register           */
        //////         uint32_t RESERVED0[24];
        //////    __IO uint32_t ICER[8];                 /*!< Offset: 0x080 (R/W)  Interrupt Clear Enable Register         */
        //////         uint32_t RSERVED1[24];
        //////    __IO uint32_t ISPR[8];                 /*!< Offset: 0x100 (R/W)  Interrupt Set Pending Register          */
        //////         uint32_t RESERVED2[24];
        //////    __IO uint32_t ICPR[8];                 /*!< Offset: 0x180 (R/W)  Interrupt Clear Pending Register        */
        //////         uint32_t RESERVED3[24];
        //////    __IO uint32_t IABR[8];                 /*!< Offset: 0x200 (R/W)  Interrupt Active bit Register           */
        //////         uint32_t RESERVED4[56];
        //////    __IO uint8_t  IP[240];                 /*!< Offset: 0x300 (R/W)  Interrupt Priority Register (8Bit wide) */
        //////         uint32_t RESERVED5[644];
        //////    __O  uint32_t STIR;                    /*!< Offset: 0xE00 ( /W)  Software Trigger Interrupt Register     */
        //////  }  NVIC_Type;
        //////
        //////  ...
        //////  ...
        //////  ...
        //////          
        //////  #define NVIC                ((NVIC_Type      *)     NVIC_BASE     )   /*!< NVIC configuration struct          */
        //////
        
        private const uint NVIC_ISERx__ENABLE___MASK           = 0xFFFFFFFFu;
        private const int  NVIC_ISERx__ENABLE___SHIFT          =           0;
        private const uint NVIC_ISERx__ENABLE___SET_ENABLED    =           1u << NVIC_ISERx__ENABLE___SHIFT;
        private const uint NVIC_ISERx__ENABLE___IS_ENABLED     =           1u << NVIC_ISERx__ENABLE___SHIFT;
        private const uint NVIC_ISERx__ENABLE___IS_DISABLED    =           0u << NVIC_ISERx__ENABLE___SHIFT;

        private const uint NVIC_ICERx__ENABLE___MASK           = 0xFFFFFFFFu;
        private const int  NVIC_ICERx__ENABLE___SHIFT          =           0;
        private const uint NVIC_ICERx__ENABLE___SET_DISABLED   =           1u << NVIC_ICERx__ENABLE___SHIFT;
        private const uint NVIC_ICERx__ENABLE___IS_ENABLED     =           1u << NVIC_ICERx__ENABLE___SHIFT;
        private const uint NVIC_ICERx__ENABLE___IS_DISABLED    =           0u << NVIC_ICERx__ENABLE___SHIFT;

        private const uint NVIC_ISPRx__ENABLE___MASK           = 0xFFFFFFFFu;
        private const int  NVIC_ISPRx__ENABLE___SHIFT          =           0;
        private const uint NVIC_ISPRx__ENABLE___SET_PENDING    =           1u << NVIC_ISPRx__ENABLE___SHIFT;
        private const uint NVIC_ISPRx__ENABLE___IS_PENDING     =           1u << NVIC_ISPRx__ENABLE___SHIFT;
        private const uint NVIC_ISPRx__ENABLE___IS_NOT_PENDING =           0u << NVIC_ISPRx__ENABLE___SHIFT;

        private const uint NVIC_ICPRx__ENABLE___MASK           = 0xFFFFFFFFu;
        private const int  NVIC_ICPRx__ENABLE___SHIFT          =           0;
        private const uint NVIC_ICPRx__ENABLE___CLEAR_PENDING  =          1u << NVIC_ICPRx__ENABLE___SHIFT;
        private const uint NVIC_ICPRx__ENABLE___IS_PENDING     =          1u << NVIC_ICPRx__ENABLE___SHIFT;
        private const uint NVIC_ICPRx__ENABLE___IS_NOT_PENDING =          0u << NVIC_ICPRx__ENABLE___SHIFT;

        private const uint NVIC_IABRx__ENABLE___MASK           = 0xFFFFFFFFu;
        private const int  NVIC_IABRx__ENABLE___SHIFT          =           0;
        private const uint NVIC_IABRx__ENABLE___IS_ACTIVE      =           1u << NVIC_IABRx__ENABLE___SHIFT;
        private const uint NVIC_IABRx__ENABLE___IS_NOT_ACTIVE  =           0u << NVIC_IABRx__ENABLE___SHIFT;

        private const uint NVIC_STIR__ENABLE___MASK            =       0xFFu;
        private const int  NVIC_STIR__ENABLE___SHIFT           =           0;

        //--//
        
        public static void EnableInterrupt( ProcessorARMv7M.IRQn_Type irq )
        {
            RT.BugCheck.Assert( irq >= 0, RT.BugCheck.StopCode.IncorrectArgument );
            
            CMSIS_STUB_NVIC_EnableIRQ( irq );
        }

        public static void DisableInterrupt( ProcessorARMv7M.IRQn_Type irq )
        {
            RT.BugCheck.Assert( irq >= 0, RT.BugCheck.StopCode.IncorrectArgument );
            
            CMSIS_STUB_NVIC_DisableIRQ( irq );
        }

        public static void SetPriority( ProcessorARMv7M.IRQn_Type irq, uint pri )
        {
            CMSIS_STUB_NVIC_SetPriority( irq, pri );
        }

        public static uint GetPriority( ProcessorARMv7M.IRQn_Type irq )
        {
            return CMSIS_STUB_NVIC_GetPriority( irq );
        }
        
        public static void SetPriorityGrouping( uint split )
        {
            CMSIS_STUB_NVIC_SetPriorityGrouping( split );
        }

        public static void SetPending( ProcessorARMv7M.IRQn_Type irq )
        {
            CMSIS_STUB_NVIC_SetPendingIRQ( irq );
        }
        
        public static void ClearPending( ProcessorARMv7M.IRQn_Type irq )
        {
            CMSIS_STUB_NVIC_ClearPendingIRQ( irq );
        }
        
        public static uint GetActive( ProcessorARMv7M.IRQn_Type irq )
        {
            return CMSIS_STUB_NVIC_GetActive( irq ); 
        }

        //--//
        
        //
        // We will implement the internal methods below with CMSIS-Core
        //

        [DllImport( "C" )]
        private static extern void CMSIS_STUB_NVIC_SetPriorityGrouping( uint PriorityGroup );
        
        [DllImport( "C" )]
        private static extern uint CMSIS_STUB_NVIC_GetPriorityGrouping();
        
        [DllImport( "C" )]
        private static extern void CMSIS_STUB_NVIC_EnableIRQ( ProcessorARMv7M.IRQn_Type IRQn );
        
        [DllImport( "C" )]
        private static extern void CMSIS_STUB_NVIC_DisableIRQ( ProcessorARMv7M.IRQn_Type IRQn );
        
        [DllImport( "C" )]
        private static extern uint CMSIS_STUB_NVIC_GetPendingIRQ( ProcessorARMv7M.IRQn_Type IRQn );
        
        [DllImport( "C" )]
        private static extern void CMSIS_STUB_NVIC_SetPendingIRQ( ProcessorARMv7M.IRQn_Type IRQn );
        
        [DllImport( "C" )]
        private static extern void CMSIS_STUB_NVIC_ClearPendingIRQ( ProcessorARMv7M.IRQn_Type IRQn );
        
        [DllImport( "C" )]
        private static extern uint CMSIS_STUB_NVIC_GetActive( ProcessorARMv7M.IRQn_Type IRQn );
        
        [DllImport( "C" )]
        private static extern void CMSIS_STUB_NVIC_SetPriority( ProcessorARMv7M.IRQn_Type IRQn, uint priority );
        
        [DllImport( "C" )]
        private static extern uint CMSIS_STUB_NVIC_GetPriority( ProcessorARMv7M.IRQn_Type IRQn );
        
        [DllImport( "C" )]
        private static extern uint CMSIS_STUB_NVIC_EncodePriority( uint PriorityGroup, uint PreemptPriority, uint SubPriority );
        
        [DllImport( "C" )]
        private static unsafe extern void CMSIS_STUB_NVIC_DecodePriority( uint Priority, uint PriorityGroup, uint* pPreemptPriority, uint* pSubPriority );
        
        [DllImport( "C" )]
        private static extern void CMSIS_STUB_NVIC_SystemReset( );

        [DllImport( "C" )]
        private static extern void CUSTOM_STUB_NVIC_RaisePendSV( );
    }
}